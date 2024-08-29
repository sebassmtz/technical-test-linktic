
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Infrastructure.Authentification
{
    public class AuthenticationProvider : IAuthorization
    {
        private readonly IGetConfiguration _getConfiguration;

        public AuthenticationProvider(IGetConfiguration getConfiguration)
        {
            _getConfiguration = getConfiguration;
        }

        public string GenerateToken(User User)
        {
            throw new NotImplementedException();
        }
    }
}
