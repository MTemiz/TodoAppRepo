using AutoMapper;
using TodoApp.Application.Todos.Queries.GetTodo;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoEntity, TodoDto>();
        }
    }
}

