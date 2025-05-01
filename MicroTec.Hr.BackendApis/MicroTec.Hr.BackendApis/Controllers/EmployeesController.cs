using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroTec.Hr.BackendApi.Features.Employees.CreateEmployee;
using MicroTec.Hr.BackendApi.Features.Employees.DeleteEmployee;
using MicroTec.Hr.BackendApi.Features.Employees.GetAllEmployees;
using MicroTec.Hr.BackendApi.Features.Employees.UpdateEmployee;
using MicroTec.Hr.Services.Employees.CreateEmployee;
using MicroTec.Hr.Services.Employees.DeleteEmployee;
using MicroTec.Hr.Services.Employees.GetAllEmployees;
using MicroTec.Hr.Services.Employees.GetEmployeeById;
using MicroTec.Hr.Services.Employees.UpdateEmployee;

namespace MicroTec.Hr.BackendApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController(IMediator mediator, IMapper mapper) : BaseApiController
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        // POST: api/employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest request)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(request) with { UserId = UserId };
            var employeeId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeId }, employeeId);
        }

        [HttpGet("{id}/")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var query = new GetEmployeeByIdQuery() { EmployeeId = id , UserId = UserId};
            var employee = await _mediator.Send(query);
            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeRequest request)
        {
            var command = new DeleteEmployeeCommand() { EmployeeId = request.Id, UserId = UserId};
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("GetAllEmployees")]
        public async Task<IActionResult> GetEmployees([FromBody] GetAllEmployeesRequest request)
        {
            var query = _mapper.Map<GetAllEmployeesQuery>(request);
            var employee = await _mediator.Send(query);
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(request) with { UserId = UserId };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
