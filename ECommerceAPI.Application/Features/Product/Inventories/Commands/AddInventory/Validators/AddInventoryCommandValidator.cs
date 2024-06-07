using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Validators
{
    public class AddInventoryCommandValidator : AbstractValidator<AddInventoryCommandRequest>
    {
        #region Constructors

        public AddInventoryCommandValidator()
        {
            QuantityValidator();
        }

        #endregion Constructors

        #region Methods

        public void QuantityValidator()
        {
            RuleFor(request => request.Quantity)
                .NotEmpty().WithMessage("Quantity can't be empty")
                .NotNull().WithMessage("Quantity can't be null")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        #endregion Methods
    }
}