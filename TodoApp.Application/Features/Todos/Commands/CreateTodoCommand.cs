using System;
using MediatR;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class CreateTodoCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

