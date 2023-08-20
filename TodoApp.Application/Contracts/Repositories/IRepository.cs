using System.Linq.Expressions;
using TodoApp.Domain.Common;
using TodoApp.Domain.PagedResponses;

namespace TodoApp.Application.Contracts.Repositories
{
    public interface IRepository<T> : IPagedRepository<T> where T : EntityBase
	{
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllQueryableAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}

