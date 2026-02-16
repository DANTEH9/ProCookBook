using Microsoft.EntityFrameworkCore;
using ProCookBook.Models;

namespace ProCookBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes => Set<Recipe>();
    }
}
