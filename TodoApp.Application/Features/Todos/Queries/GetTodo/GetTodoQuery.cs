using System;
using MediatR;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Todos.Queries.GetTodo
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public int Id { get; set; }
    }
}

