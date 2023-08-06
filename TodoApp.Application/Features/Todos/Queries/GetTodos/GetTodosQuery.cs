using MediatR;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Todos.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<List<TodoDto>>
    {
    }
}

