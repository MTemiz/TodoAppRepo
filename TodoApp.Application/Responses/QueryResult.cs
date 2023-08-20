namespace TodoApp.Application.Responses
{
    public class QueryResult<T>
    {
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }

        public List<string> Errors { get; private set; }
        public List<string> InfoMessages { get; private set; }
        public T Result { get; set; }

        public QueryResult()
        {
            Errors = new();
            InfoMessages = new();
        }

        public void AddError(string message)
        {
            Errors.Add(message);
        }

        public void AddInfo(string message)
        {
            InfoMessages.Add(message);
        }
    }
}

