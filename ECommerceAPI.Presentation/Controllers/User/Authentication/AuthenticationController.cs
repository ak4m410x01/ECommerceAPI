using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using ECommerceAPI.Presentation.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.User.Authentication
{
    public class AuthenticationController : APIBaseController
    {
        #region Properties

        private readonly IMediator _mediator;

        #endregion Properties

        #region Constructors

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Constructors

        #region Methods

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpAsync(SignUpCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion Methods
    }
}