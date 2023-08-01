using TodoApp.Domain.Entities;

namespace TodoApp.Application.Contracts.Repositories
{
    public interface ITodoRepository
    {
        Task<TodoEntity> GetByIdAsync(int id);
        Task<List<TodoEntity>> GetAllAsync();
        Task<TodoEntity> CreateAsync(TodoEntity todo);
        Task<TodoEntity> UpdateAsync(TodoEntity todo);
        Task DeleteAsync(int id);
    }
}

