using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Domain.Common;
using TodoApp.Domain.PagedResponses;

namespace TodoApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);

            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllQueryableAsync()
        {
            return (IQueryable<T>)await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<EntityPagedResponse<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var totalItemCount = await query.CountAsync();

            pageNumber++;

            var skipAmount = (pageNumber - 1) * pageSize;

            var pagedData = await query
            .OrderBy(c => c.Id)
            .Skip(skipAmount)
            .Take(pageSize)
            .ToListAsync();

            return new EntityPagedResponse<T>()
            {
                Data = pagedData,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalItemCount
            };
        }

        public async Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            await Task.CompletedTask;
        }
    }
}

