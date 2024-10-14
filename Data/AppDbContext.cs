using Microsoft.EntityFrameworkCore;
using WebApplication_Login.Models;

namespace WebApplication_Login.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext() 
        {
        }
        public DbSet<Create> creates { get; set;} =null!;
        public DbSet<LoginUser1> LoginBTNClicks { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
