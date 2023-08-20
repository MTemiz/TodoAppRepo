using TodoApp.Application.Contracts.Repositories;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : GenericRepository<TodoEntity>, ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
