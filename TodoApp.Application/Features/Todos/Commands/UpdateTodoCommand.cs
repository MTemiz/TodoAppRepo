using MediatR;

namespace TodoApp.Application.Features.Todos.Commands
{
    public class UpdateTodoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

