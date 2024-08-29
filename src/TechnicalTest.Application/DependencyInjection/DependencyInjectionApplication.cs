using Microsoft.Extensions.DependencyInjection;

namespace TechnicalTest.Application.DependencyInjection
{
    public static class DependencyInjectionApplication
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjectionApplication).Assembly);
            });

        }
    }
}
