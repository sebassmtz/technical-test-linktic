using Microsoft.EntityFrameworkCore;

namespace TechnicalTest.Infrastructure.EntityFramework.Contexts
{
    public class ContextApp : DbContext
    {

        // Add DbSet for each entity

        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
