using TodoApp.Application.Contracts.Repositories;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoUnitOfWork : ITodoUnitOfWork
    {
        private readonly TodoDbContext _dbContext;

        private ITodoRepository _todoRepository;

        public TodoUnitOfWork(TodoDbContext dbContext, ITodoRepository todoRepository)
        {
            _dbContext = dbContext;
            _todoRepository = todoRepository;
        }

        public ITodoRepository TodoRepository => _todoRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

