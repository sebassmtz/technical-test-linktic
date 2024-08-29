using System.Linq.Expressions;
using TechnicalTest.Domain.Common.Entities;

namespace TechnicalTest.Domain.Common.Ports
{
    public interface IGenericRepository
    {
        Task<T?> Get<T>(Expression<Func<T, bool>> expression) where T : Entity;

        Task<List<T>> GetAll<T>(Expression<Func<T, bool>>? expression = null) where T : Entity;
        void Save<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;
    }
}
