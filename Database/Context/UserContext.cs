using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=DESKTOP-NI9RJP9\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True");
        }
    }
}