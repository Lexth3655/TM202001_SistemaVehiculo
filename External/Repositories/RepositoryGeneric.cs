using Core.Interfaces.Repository;
using Persistence.Data;
using System.Linq.Expressions;

namespace External.Repositories
{
    public class RepositoryGeneric<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryGeneric(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateNextCodigoAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>>? orderBy = null, bool ascending = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}
