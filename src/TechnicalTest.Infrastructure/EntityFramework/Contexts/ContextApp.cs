using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Infrastructure.EntityFramework.Contexts
{
    public class ContextApp : DbContext
    {

        // Add DbSet for each entity
        public DbSet<User> Users { get; set; }

        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
