﻿using System;
namespace TodoApp.Application.Todos.Queries.GetTodo
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}

