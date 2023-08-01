using MediatR;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Domain.Entities;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
{
    private readonly ITodoUnitOfWork _unitOfWork;

    public CreateTodoCommandHandler(ITodoUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new TodoEntity
        {
            Title = request.Title,
            Description = request.Description
        };

        await _unitOfWork.TodoRepository.CreateAsync(todo);
        await _unitOfWork.SaveChangesAsync();

        return todo.Id;
    }
}
