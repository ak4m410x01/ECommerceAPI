using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Validators
{
    public class GetAllDiscountsQueryValidator : AbstractValidator<GetAllDiscountsQueryRequest>
    {
        #region Constructors

        public GetAllDiscountsQueryValidator()
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