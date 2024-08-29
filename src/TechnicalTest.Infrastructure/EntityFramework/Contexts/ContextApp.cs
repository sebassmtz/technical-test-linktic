using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.Reserves.Entities;
using TechnicalTest.Domain.ReseveService.Entities;
using TechnicalTest.Domain.Services.Entities;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Infrastructure.EntityFramework.Contexts
{
    public class ContextApp : DbContext
    {

        // Add DbSet for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ReserveService> ReserveServices { get; set; }

        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
