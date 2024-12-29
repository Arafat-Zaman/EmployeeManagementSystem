using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeeManagementSystem.Features.Departments.Commands;
using EmployeeManagementSystem.Features.Departments.Queries;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/departments")]
    [ApiVersion("1.0")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var query = new GetAllDepartmentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var departmentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllDepartments), new { id = departmentId }, departmentId);
        }
    }
}
