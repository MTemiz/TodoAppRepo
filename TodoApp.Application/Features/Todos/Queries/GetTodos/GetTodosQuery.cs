using System;
using MediatR;
using TodoApp.Application.Todos.Queries.GetTodo;

namespace TodoApp.Application.Todos.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<List<TodoDto>>
    {
    }
}

