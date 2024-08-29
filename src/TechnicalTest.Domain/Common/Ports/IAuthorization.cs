using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Domain.Common.Ports
{
    public interface IAuthorization
    {
        string GenerateToken(User user);
    }
}
