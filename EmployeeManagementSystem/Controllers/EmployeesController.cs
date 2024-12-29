using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeeManagementSystem.Features.Employees.Commands;
using EmployeeManagementSystem.Features.Employees.Queries;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employees")]
    [ApiVersion("1.0")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var query = new GetEmployeeByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var employeeId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeId }, employeeId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != command.Id) return BadRequest("Employee ID mismatch.");
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var command = new DeleteEmployeeCommand(id);
        //    var result = await _mediator.Send(command);
        //    return result ? NoContent() : NotFound();
        //}
    }
}
