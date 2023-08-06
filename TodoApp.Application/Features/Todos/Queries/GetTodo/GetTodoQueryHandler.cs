using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Todos.Queries.GetTodo
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id);

            if (todo == null)
            {
                // Burada NotFoundException fırlatılabilir.
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }

            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            };
        }
    }
}

