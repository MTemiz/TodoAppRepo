using System;
using MediatR;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class CreateTodoCommand : IRequest<TodoDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

