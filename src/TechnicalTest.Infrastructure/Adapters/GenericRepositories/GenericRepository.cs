using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechnicalTest.Domain.Common.Entities;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Infrastructure.EntityFramework.Contexts;

namespace TechnicalTest.Infrastructure.Adapters.GenericRepositories
{
    public class GenericRepository : IGenericRepository

    {
        private readonly ContextApp _context;

        public GenericRepository(ContextApp context)
        {
            _context = context;
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return _context.Set<T>().Any(expression);
        }

        public async Task<T?> Get<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>>? expression = null) where T : Entity
        {
            if (expression == null)
            {
                return await _context.Set<T>().ToListAsync();
            }
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public void Save<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Set<T>().Update(entity);
        }
    }
}
