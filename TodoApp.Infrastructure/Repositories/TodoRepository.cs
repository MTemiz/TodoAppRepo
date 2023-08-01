using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TodoEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TodoEntity>().FindAsync(id);
        }

        public async Task<List<TodoEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TodoEntity>().ToListAsync();
        }

        public async Task<TodoEntity> CreateAsync(TodoEntity todo)
        {
            await _dbContext.Set<TodoEntity>().AddAsync(todo);
            return todo;
        }

        public async Task<TodoEntity> UpdateAsync(TodoEntity todo)
        {
            _dbContext.Set<TodoEntity>().Update(todo);
            return todo;
        }

        public async Task DeleteAsync(int id)
        {
        }
    }
}
