using TodoApp.Domain.Common;

namespace TodoApp.Domain.Entities
{
    public class TodoEntity : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

