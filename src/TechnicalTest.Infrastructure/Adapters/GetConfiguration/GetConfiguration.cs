
using Microsoft.Extensions.Configuration;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Common.Exceptions;

namespace TechnicalTest.Infrastructure.Adapters.GetConfiguration
{
    public class GetConfiguration : IGetConfiguration
    {
        private readonly IConfiguration _configuration;

        public GetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        T IGetConfiguration.GetConfiguration<T>(string key)
        {
            return _configuration.GetSection(key).Get<T>() ?? throw new ConfDomainException($"Key not found {key}");
        }
    }
}
