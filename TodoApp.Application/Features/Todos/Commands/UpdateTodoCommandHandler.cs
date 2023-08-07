using AutoMapper;
using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Domain.Entities;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, TodoDto>
{
    private readonly ITodoUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTodoCommandHandler(ITodoUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id);

        if (todo == null)
        {
            throw new NotFoundException(nameof(TodoEntity), request.Id);
        }

        todo.Title = request.Title;

        todo.Description = request.Description;

        todo.IsCompleted = request.IsCompleted;

        await _unitOfWork.TodoRepository.UpdateAsync(todo);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TodoDto>(todo);
    }
}
