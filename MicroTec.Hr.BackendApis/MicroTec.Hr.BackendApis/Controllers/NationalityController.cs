using MediatR;
using Microsoft.AspNetCore.Mvc;
using MicroTec.Hr.Services.Nationalities.GetNationalitiesList;

namespace MicroTec.Hr.BackendApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class NationalityController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAllNationalities()
        {
            var query = new GetNationalitiesListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
