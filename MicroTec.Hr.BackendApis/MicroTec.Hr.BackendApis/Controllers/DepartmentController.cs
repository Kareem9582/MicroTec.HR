using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroTec.Hr.BackendApi.Features.Departments.CreateDepartment;
using MicroTec.Hr.BackendApi.Features.Departments.DeleteDepartment;
using MicroTec.Hr.BackendApi.Features.Departments.GetAllDepartment;
using MicroTec.Hr.BackendApi.Features.Departments.UpdateDepartment;
using MicroTec.Hr.Services.Departments.CreateDep;
using MicroTec.Hr.Services.Departments.DeleteDep;
using MicroTec.Hr.Services.Departments.GetAllDep;
using MicroTec.Hr.Services.Departments.GetDepById;
using MicroTec.Hr.Services.Departments.UpdateDep;

namespace MicroTec.Hr.BackendApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentController  (IMediator mediator, IMapper mapper) : BaseApiController
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromBody] DeleteDepartmentRequest request)
        {
            var command = new DeleteDepCommand() { DepartmentId = request.ID, UserId = UserId };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            var command = _mapper.Map<CreateDepCommand>(request) with { UserId = UserId };
          
            var DepID = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDepartmentById), new { id = DepID }, DepID);
        }

        [HttpGet("{id}/")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var query = new GetDepByIdQuery() { DepID = id, UserId = UserId };
            var department = await _mediator.Send(query);
            return Ok(department);
        }

        [HttpPost("GetAllDepartments")]
        public async Task<IActionResult> GetDepartments([FromBody] GetAllDepartmentRequest request)
        {
            var query = _mapper.Map<GetAllDepartmentQuery>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeprtment([FromBody] UpdateDepartmentRequest request)
        {
            var command = _mapper.Map<UpdateDepCommand>(request) with { UserId = UserId };
            await _mediator.Send(command);

            return NoContent();
        }





    }
}
