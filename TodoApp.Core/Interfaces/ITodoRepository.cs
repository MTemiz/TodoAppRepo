using System;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(int id);
        Task<List<Todo>> GetAllAsync();
        Task<Todo> CreateAsync(Todo todo);
        Task<Todo> UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}

