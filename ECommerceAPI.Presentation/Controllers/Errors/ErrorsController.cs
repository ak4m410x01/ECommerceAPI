using ECommerceAPI.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Errors
{
    [Route("Api/[controller]/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            return NotFound(new ResponseHandler().NotFound<object>("Resource Not Found"));
        }
    }
}