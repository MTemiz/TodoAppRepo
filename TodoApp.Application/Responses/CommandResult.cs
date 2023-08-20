using System;
namespace TodoApp.Application.Responses
{
    public class CommandResult<T>
    {
        public List<string> Errors { get; set; }
        public List<string> InfoMessages { get; set; }
        public T Data { get; set; }
    }
}

