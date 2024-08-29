
using System.Security.Claims;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

namespace TechnicalTest.Infrastructure.Authentification
{
    public class AuthenticationProvider : IAuthorization
    {
        private readonly IGetConfiguration _getConfiguration;

        public AuthenticationProvider(IGetConfiguration getConfiguration)
        {
            _getConfiguration = getConfiguration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim> {
                new(ClaimTypes.PrimarySid, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
            };
            var jwtSecret = _getConfiguration.GetConfiguration<string>("Jwt:Key");
            var issuer = _getConfiguration.GetConfiguration<string>("Jwt:Issuer");
            var audience = _getConfiguration.GetConfiguration<string>("Jwt:Audience");

            var sigingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            DateTime.Now,
            DateTime.UtcNow.AddHours(4),
            sigingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string EncryptPassword(string password)
        {
            //instancias variables
            SHA1 sha1 = SHA1.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream;
            StringBuilder sb = new StringBuilder();

            //encriptar
            stream = sha1.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}
