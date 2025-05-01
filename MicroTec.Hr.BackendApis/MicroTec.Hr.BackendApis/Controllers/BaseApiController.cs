using Microsoft.AspNetCore.Mvc;

namespace MicroTec.Hr.BackendApi.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected Guid UserId => new Guid("2f532b1f-9e16-4bb5-b489-8426faadc02f"); //Static Add the Auth code that will bring the userId here 
    }
}
