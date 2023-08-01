using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.Todos.Commands;
using TodoApp.Application.Todos.Queries.GetTodo;
using TodoApp.Application.Todos.Queries.GetTodos;

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
            var query = new GetTodosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTodoQuery { Id = id };
            var result = await _mediator.Send(query);
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
    }
}

