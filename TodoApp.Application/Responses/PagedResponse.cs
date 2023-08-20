using System;
namespace TodoApp.Application.Responses
{
	public class PagedResponse<T>
    {
        public List<T> Collections { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}

