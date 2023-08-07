using AutoMapper;
using TodoApp.Application.Dtos;
using TodoApp.Application.Features.Todos.Commands;
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

