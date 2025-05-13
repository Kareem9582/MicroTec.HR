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
    public class DepartmentController  (IMediator mediator, IMapper mapper) : BaseApiController
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;
       



    }
}
