using System;
namespace TodoApp.Core.Interfaces
{
    public interface ITodoUnitOfWork : IDisposable
    {
        ITodoRepository TodoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

