using System;
using TodoApp.Application.Responses;
using TodoApp.Models;

namespace TodoApp.Mapper
{
    public class ApiResponseMapper
    {
        public static ApiResponse<T> MapFromCommandResult<T>(CommandResult<T> commandResult, int statusCode = 200)
        {
            var apiResponse = new ApiResponse<T>
            {
                Succeeded = commandResult.Errors.Count == 0,
                StatusCode = statusCode,
                Errors = commandResult.Errors,
                InfoMessages = commandResult.InfoMessages,
                Result = commandResult.Data
            };

            return apiResponse;
        }

        public static ApiResponse<T> MapFromQueryResult<T>(QueryResult<T> queryResult, int statusCode = 200)
        {
            var apiResponse = new ApiResponse<T>
            {
                Succeeded = queryResult.Success,
                StatusCode = statusCode,
                Errors = queryResult.Errors,
                InfoMessages = queryResult.InfoMessages,
                Result = queryResult.Result
            };

            return apiResponse;
        }
    }
}

