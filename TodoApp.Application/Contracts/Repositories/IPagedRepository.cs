using System.Linq.Expressions;
using TodoApp.Domain.Common;
using TodoApp.Domain.PagedResponses;

namespace TodoApp.Application.Contracts.Repositories
{
    public interface IPagedRepository<T> where T : EntityBase
    {
        Task<EntityPagedResponse<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null);
    }
}

