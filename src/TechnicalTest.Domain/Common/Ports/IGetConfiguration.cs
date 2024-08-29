

namespace TechnicalTest.Domain.Common.Ports
{
    public interface IGetConfiguration
    {
        T GetConfiguration<T>(string key);
    }
}
