using ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.AddInventory.Validators
{
    public class AddInventoryCommandValidator : AbstractValidator<AddInventoryCommandRequest>
    {
        #region Constructors

        public AddInventoryCommandValidator()
        {
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            QuantityValidator();
        }

        private void QuantityValidator()
        {
            RuleFor(request => request.Quantity)
                .NotEmpty().WithMessage("Quantity  is required field.")
                .NotNull().WithMessage("Quantity must be not null.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }

        #endregion Methods
    }
}