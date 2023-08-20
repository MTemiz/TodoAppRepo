using System;
namespace TodoApp.Models
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public List<string> InfoMessages { get; set; }

        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T>()
            {
                Succeeded = false,
                Errors = new List<string>() { errorMessage}
            };
        }
        public static ApiResponse<T> Success(T result)
        {
            return new ApiResponse<T> { Succeeded = true, Result = result };
        }
    }
}

