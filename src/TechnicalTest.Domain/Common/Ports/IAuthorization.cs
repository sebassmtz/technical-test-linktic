namespace TechnicalTest.Domain.Common.Ports
{
    public interface IAuthorization
    {
        string GenerateToken(string token);
    }
}
