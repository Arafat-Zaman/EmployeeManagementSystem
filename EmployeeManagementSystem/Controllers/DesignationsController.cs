using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeeManagementSystem.Features.Designations.Commands;
using EmployeeManagementSystem.Features.Designations.Queries;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/designations")]
    [ApiVersion("1.0")]
    public class DesignationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DesignationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var query = new GetAllDesignationsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDesignation([FromBody] CreateDesignationCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var designationId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllDesignations), new { id = designationId }, designationId);
        }
    }
}
