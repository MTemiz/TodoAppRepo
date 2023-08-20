using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Application.Features.Todos.Queries.GetTodosPaging;
using TodoApp.Application.Todos.Queries.GetTodo;
using TodoApp.Application.Todos.Queries.GetTodos;
using TodoApp.Mapper;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTodosQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTodoQuery { Id = id });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTodoCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] GetTodosPagingQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(ApiResponseMapper.MapFromQueryResult(result));
        }
    }
}

