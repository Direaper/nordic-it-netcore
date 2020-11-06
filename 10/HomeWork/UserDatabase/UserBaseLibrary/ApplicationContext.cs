using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace UserDatabaseLibrary
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=userbase;Trusted_Connection=True;");
        }

    }
}
