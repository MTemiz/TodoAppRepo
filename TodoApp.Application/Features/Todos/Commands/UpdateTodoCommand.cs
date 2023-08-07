using MediatR;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class UpdateTodoCommand : IRequest<TodoDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

