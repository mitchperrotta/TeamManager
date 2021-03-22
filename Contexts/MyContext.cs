using Microsoft.EntityFrameworkCore;
using TeamManager.Models;

namespace TeamManager.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users {get;set;}
        public DbSet<Facility> Facilitys {get;set;}
        public DbSet<League> Leagues {get;set;}
        public DbSet<Player> Players {get;set;}
        public DbSet<Staff> Staffs {get;set;}
        public DbSet<Team> Teams {get;set;}
    }
}