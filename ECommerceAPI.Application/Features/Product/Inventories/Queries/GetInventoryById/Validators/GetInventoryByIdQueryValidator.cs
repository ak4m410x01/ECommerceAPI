using ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.Validators
{
    public class GetInventoryByIdQueryValidator : AbstractValidator<GetInventoryByIdQueryRequest>
    {
        public GetInventoryByIdQueryValidator()
        {
            IdValidator();
        }

        public void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must greater than 1.");
        }
    }
}