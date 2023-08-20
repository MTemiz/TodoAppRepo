using MediatR;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Queries.BaseQuery;
using TodoApp.Application.Responses;

namespace TodoApp.Application.Features.Todos.Queries.GetTodosPaging
{
    public class GetTodosPagingQuery : PagedQuery, IRequest<QueryResult<PagedResponse<TodoDto>>>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}

