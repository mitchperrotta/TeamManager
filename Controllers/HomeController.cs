using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeamManager.Models;
using TeamManager.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TeamManager.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public User UserInDb()
        {
            return dbContext.Users.Include(u => u.Teams).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Username is already taken");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser log)
        {
            if(ModelState.IsValid)
            {
                User user = dbContext.Users.FirstOrDefault(u => u.Username == log.LoginUsername);
                if(user != null)
                {
                    var hash = new PasswordHasher<LoginUser>();
                    var result = hash.VerifyHashedPassword(log, user.Password, log.LoginPassword);
                    if(result == 0)
                    {
                        ModelState.AddModelError("LoginUsername", "Invalid login attempt");
                        return View("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        return RedirectToAction("Dashboard");
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginUsername", "Invalid login attempt");
                    return View("Index");
                }
            }
            return View("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }

            
            return View(userInDb);
        }

        [HttpGet("new/team")]
        public IActionResult TeamForm()
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("logout");
            }
            return View();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
