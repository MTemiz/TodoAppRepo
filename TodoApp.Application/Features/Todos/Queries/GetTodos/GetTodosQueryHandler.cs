using AutoMapper;
using MediatR;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Todos.Queries.GetTodos
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<TodoDto>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TodoDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _repository.GetAllAsync();

            return _mapper.Map<List<TodoDto>>(todos);
        }
    }
}

