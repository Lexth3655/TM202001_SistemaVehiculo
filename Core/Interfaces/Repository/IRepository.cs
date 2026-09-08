using System.Linq.Expressions;

namespace Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        //Consultas
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, Expression<Func<T, object>>? orderBy = null,
        bool ascending = true, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        //Comandos
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<string> GenerateNextCodigoAsync(CancellationToken cancellationToken);

    }
}
