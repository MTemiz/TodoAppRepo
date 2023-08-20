using System;
using TodoApp.Domain.Common;

namespace TodoApp.Domain.PagedResponses
{
	public class EntityPagedResponse<T> where T : EntityBase
	{
		public List<T> Data { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
	}
}

