using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Infrastructure.Adapters.GenericRepositories;
using TechnicalTest.Infrastructure.Adapters.GetConfiguration;
using TechnicalTest.Infrastructure.Adapters.UnitOfWork;
using TechnicalTest.Infrastructure.EntityFramework.Contexts;


namespace TechnicalTest.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);
            AddInjections(services);
            return services;
        }

        public static void AddPersistence(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextApp>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("StringConnection"));
            });
        }

        public static void AddAuthentificationJWT(IServiceCollection services, IConfiguration configuration)
        {

        }

        public static void AddInjections(IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGetConfiguration, GetConfiguration>();
        }
    }
}
