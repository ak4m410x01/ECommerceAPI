using ECommerceAPI.Presentation.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.User
{
    [Route("Api/User/[controller]")]
    public class UserAPIBaseController : APIBaseController
    {
        #region Constructors

        public UserAPIBaseController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors
    }
}