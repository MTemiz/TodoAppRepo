using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Todos.Queries.GetTodos
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoDto>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTodosQueryHandler> _logger;

        public GetTodosQueryHandler(ITodoRepository repository, IMapper mapper, ILogger<GetTodosQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _repository.GetAllAsync();

            throw new ApplicationException("asdasd");
            return _mapper.Map<List<TodoDto>>(todos);
        }
    }
}

