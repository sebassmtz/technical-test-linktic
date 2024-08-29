
namespace TechnicalTest.Domain.Common.Ports
{
    public interface IUnitOfWork
    {

        Task Commit();
    }
}
