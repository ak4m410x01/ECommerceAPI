using ECommerceAPI.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.Presentation.Controllers.Base
{
    [Route("Api/[controller]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        #region Properties

        public IMediator Mediator { get; protected set; }

        #endregion Properties

        #region Constructors

        public APIBaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        #endregion Constructors

        #region Methods

        public IActionResult ResponseResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);

                case HttpStatusCode.Created:
                    return Created("", response);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(response);

                case HttpStatusCode.BadRequest:
                    return BadRequest(response);

                case HttpStatusCode.NotFound:
                    return NotFound(response);

                case HttpStatusCode.NoContent:
                    return Ok(response);
            }
            return Ok(response);
        }

        #endregion Methods
    }
}