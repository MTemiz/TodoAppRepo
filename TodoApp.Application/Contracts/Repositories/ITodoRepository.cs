using System.Linq.Expressions;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Contracts.Repositories
{
    public interface ITodoRepository: IRepository<TodoEntity>
    {
    }
}

