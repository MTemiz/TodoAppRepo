using System;
using MediatR;

namespace TodoApp.Application.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}

