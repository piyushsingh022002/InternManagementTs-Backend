using Microsoft.EntityFrameworkCore;
using Backend.Models;


namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Intern> Interns { get; set; }

    }
}
