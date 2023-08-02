using AutoMapper;
using MediatR;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Domain.Entities;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, TodoDto>
{
    private readonly ITodoUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTodoCommandHandler(ITodoUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TodoDto> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new TodoEntity
        {
            Title = request.Title,
            Description = request.Description
        };

        await _unitOfWork.TodoRepository.CreateAsync(todo);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TodoDto>(todo);
    }
}
