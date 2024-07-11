using ECommerceAPI.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Errors
{
    [Route("Api/V{version:apiVersion}/[controller]/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error(int code)
        {
            var responseHandler = new ResponseHandler();

            return code switch
            {
                StatusCodes.Status401Unauthorized => Unauthorized(responseHandler.Unauthorized<object>("Unauthorized or Invalid token.")),
                StatusCodes.Status403Forbidden => StatusCode(StatusCodes.Status403Forbidden, responseHandler.Forbidden<object>("Access Forbidden.")),
                StatusCodes.Status404NotFound => NotFound(responseHandler.NotFound<object>("Resource Not Found.")),
                StatusCodes.Status405MethodNotAllowed => StatusCode(code, responseHandler.MethodNotAllowed<object>()),
                _ => StatusCode(code, responseHandler.ServerError<object>("An unexpected error occurred."))
            };
        }
    }
}