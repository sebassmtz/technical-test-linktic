using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApp.Middleware;

namespace WebApp.DependencyInjection
{
    public static class DependencyInjectionWeb
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
               x =>
               {
                   x.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Title = "JWT",
                       Version = "v1"
                   });
                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   x.IncludeXmlComments(xmlPath);
                   x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       Name = "Authorization",
                       Type = SecuritySchemeType.Http,
                       Scheme = "bearer",
                       BearerFormat = "JWT",
                       In = ParameterLocation.Header,
                       Description = "Token JWT (sin el prefijo 'Bearer')"
                   });
                   x.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                 Reference = new OpenApiReference
                                {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                                }
                            },
                             new string[]{}
                         }
                     });
               });
            services.AddTransient<GlobalExceptionHandler>();
            return services;
        }
    }
}
