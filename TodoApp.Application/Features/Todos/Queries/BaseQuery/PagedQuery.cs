using System;
namespace TodoApp.Application.Features.Todos.Queries.BaseQuery
{
	public class PagedQuery
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}

