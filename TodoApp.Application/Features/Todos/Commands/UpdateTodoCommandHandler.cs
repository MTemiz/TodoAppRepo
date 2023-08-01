using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Domain.Entities;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoUnitOfWork _unitOfWork;

    public UpdateTodoCommandHandler(ITodoUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id);

        if (todo == null)
        {
            throw new NotFoundException(nameof(TodoEntity), request.Id);
        }

        todo.Title = request.Title;

        todo.Description = request.Description;

        await _unitOfWork.TodoRepository.UpdateAsync(todo);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
