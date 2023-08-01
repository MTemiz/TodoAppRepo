using System;
namespace TodoApp.Application.Contracts.Repositories
{
    public interface ITodoUnitOfWork : IDisposable
    {
        ITodoRepository TodoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

