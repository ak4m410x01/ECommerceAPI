using ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Products.Queries.GetAllProducts.Validators
{
    public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQueryRequest>
    {
        #region Constructors

        public GetAllProductsQueryValidator()
        {
            PageNumberValidator();
            PageSizeValidator();
        }

        #endregion Constructors

        #region Methods

        public void PageNumberValidator()
        {
            RuleFor(request => request.PageNumber)
                .GreaterThan(0).WithMessage("PageNumber must be greater than 1.");
        }

        public void PageSizeValidator()
        {
            RuleFor(request => request.PageSize)
                .GreaterThan(0).WithMessage("PageSize must be greater than 1.");
        }

        #endregion Methods
    }
}