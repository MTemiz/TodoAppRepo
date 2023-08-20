using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TodoApp.Application.Contracts.Repositories;
using TodoApp.Application.Dtos;
using TodoApp.Application.Responses;
using TodoApp.Application.Todos.Queries.GetTodos;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.Todos.Queries.GetTodosPaging
{
    public class GetTodosPagingQueryHandler : IRequestHandler<GetTodosPagingQuery, QueryResult<PagedResponse<TodoDto>>>
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTodosQueryHandler> _logger;

        public GetTodosPagingQueryHandler(ITodoRepository repository, IMapper mapper, ILogger<GetTodosQueryHandler> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<QueryResult<PagedResponse<TodoDto>>> Handle(GetTodosPagingQuery request, CancellationToken cancellationToken)
        {
            var result = new QueryResult<PagedResponse<TodoDto>>();

            Expression<Func<TodoEntity, bool>> searchCriteria = x =>
            (string.IsNullOrWhiteSpace(request.Title) || x.Title.Contains(request.Title)) &&
            (string.IsNullOrWhiteSpace(request.Description) || x.Description.Contains(request.Description)) &&
            (!request.IsCompleted.HasValue || x.IsCompleted == request.IsCompleted);

            var pagedResponse = await _repository.GetPagedAsync(request.PageNumber, request.PageSize, searchCriteria);

            List<TodoDto> destinationList = _mapper.Map<List<TodoDto>>(pagedResponse.Data);

            result.Result = new PagedResponse<TodoDto>()
            {
                Collections = destinationList,
                PageNumber = pagedResponse.PageNumber,
                PageSize = pagedResponse.PageSize,
                TotalCount = pagedResponse.TotalCount
            };

            return result;
        }
    }
}

