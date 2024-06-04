using ECommerceAPI.Presentation.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Presentation.Controllers.Product
{
    [Route("Api/Product/[controller]")]
    public class ProductAPIBaseController : APIBaseController
    {
        #region Constructors

        public ProductAPIBaseController(IMediator mediator) : base(mediator)
        {
        }

        #endregion Constructors
    }
}