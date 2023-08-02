﻿using AutoMapper;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoEntity, TodoApp.Application.Todos.Queries.GetTodo.TodoDto>();
            CreateMap<TodoEntity, TodoApp.Application.Dtos.TodoDto>();
        }
    }
}

