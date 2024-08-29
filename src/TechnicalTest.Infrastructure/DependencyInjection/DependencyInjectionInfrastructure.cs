using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Text;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Infrastructure.Adapters.GenericRepositories;
using TechnicalTest.Infrastructure.Adapters.GetConfiguration;
using TechnicalTest.Infrastructure.Adapters.UnitOfWork;
using TechnicalTest.Infrastructure.Authentification;
using TechnicalTest.Infrastructure.EntityFramework.Contexts;


namespace TechnicalTest.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);
            AddInjections(services);
            AddAuthentificationJWT(services, configuration);
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
            var jwtSecret = configuration.GetValue<string>("Jwt:Key") ?? throw new ConfDomainException("Key not found");

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8
                        .GetBytes(jwtSecret)
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddInjections(IServiceCollection services)
        {
            services.AddScoped<IAuthorization, AuthenticationProvider>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGetConfiguration, GetConfiguration>();
        }
    }
}
