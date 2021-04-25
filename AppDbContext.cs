using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OptionsListApp.Models;

namespace OptionsListApp
{
    class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OptionsListApp;Trusted_Connection=True");
        }

        public DbSet<MoreOption> MoreOption { get; set; }

        public DbSet<MoreOptionType> MoreOptionType { get; set; }

        public DbSet<Value> Values { get; set; }
    }
}
