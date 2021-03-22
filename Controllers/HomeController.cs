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
            List<League> leagues = dbContext.Leagues.ToList();
            ViewBag.AllLeagues = leagues;
            ViewBag.User = userInDb;
            return View();
        }

        [HttpPost("create/team")]
        public IActionResult CreateTeam(Team team)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            if(ModelState.IsValid)
            {
                if(dbContext.Teams.Any(u => u.Name == team.Name))
                {
                    ModelState.AddModelError("Name", "Team name is already taken");
                    return View("Index");
                }
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("TeamForm");
        }

        [HttpGet("{teamId}")]
        public IActionResult TeamDash(int teamId)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            Team team = dbContext.Teams.FirstOrDefault(t => t.TeamId == teamId);
            return View(team);
        }

        [HttpGet("new/league")]
        public IActionResult LeagueForm()
        {
            User userInDb = UserInDb();
            if(userInDb.Username != "adminlog")
            {
                return RedirectToAction("logout");
            }
            return View();
        }

        [HttpPost("create/league")]
        public IActionResult CreateLeague(League league)
        {
            User userInDb = UserInDb();
            if(userInDb == null)
            {
                return RedirectToAction("Logout");
            }
            if(ModelState.IsValid)
            {
                dbContext.Leagues.Add(league);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("LeagueForm");
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
