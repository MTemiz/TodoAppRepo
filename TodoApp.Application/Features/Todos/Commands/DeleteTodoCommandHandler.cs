using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Domain.Entities;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoUnitOfWork _unitOfWork;

    public DeleteTodoCommandHandler(ITodoUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id);

        if (todo == null)
        {
            throw new NotFoundException(nameof(TodoEntity), request.Id);
        }

        await _unitOfWork.TodoRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
