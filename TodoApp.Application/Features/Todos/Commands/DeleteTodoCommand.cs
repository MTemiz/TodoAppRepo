using MediatR;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class DeleteTodoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

