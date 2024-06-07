using ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ProductEntity = ECommerceAPI.Domain.Entities.Products.Product;
using FluentValidation;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Application.Features.Product.Products.Commands.AddProduct.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommandRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<ProductEntity> _productSpecification;
        private readonly IBaseSpecification<Category> _categorySpecification;
        private readonly IBaseSpecification<Inventory> _inventorySpecification;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #region Constructors

        public AddProductCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<ProductEntity> productSpecification, IBaseSpecification<Category> categorySpecification, IBaseSpecification<Inventory> inventorySpecification, IBaseSpecification<Discount> discountSpecification)
        {
            _unitOfWork = unitOfWork;
            _productSpecification = productSpecification;
            _categorySpecification = categorySpecification;
            _inventorySpecification = inventorySpecification;
            _discountSpecification = discountSpecification;
            NameValidator();
            SKUValidator();
            CategoryIdValidator();
            InventoryIdValidator();
            DiscountIdValidator();
        }

        #endregion Constructors

        #region Methods

        public void NameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .NotNull().WithMessage("Name can't be null");
        }

        public void SKUValidator()
        {
            RuleFor(request => request.SKU)
                .NotEmpty().WithMessage("SKU can't be empty")
                .NotNull().WithMessage("SKU can't be null")
                .MustAsync(async (sku, cancellationToken) =>
                {
                    _productSpecification.Criteria = product => product.SKU == sku;
                    return (await _unitOfWork.Repository<ProductEntity>().FindAsNoTrackingAsync(_productSpecification)) is null;
                }).WithMessage("SKU already exists."); ;
        }

        public void PriceValidator()
        {
            RuleFor(request => request.Price)
                .NotEmpty().WithMessage("Price can't be empty")
                .NotNull().WithMessage("Price can't be null")
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }

        public void CategoryIdValidator()
        {
            RuleFor(request => request.CategoryId)
                .NotEmpty().WithMessage("CategoryId can't be empty")
                .NotNull().WithMessage("CategoryId can't be null")
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.")
                .MustAsync(async (categoryId, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Id == categoryId;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is not null;
                }).WithMessage("CategoryId doesn't exists."); ;
        }

        public void InventoryIdValidator()
        {
            RuleFor(request => request.InventoryId)
                .NotEmpty().WithMessage("InventoryId can't be empty")
                .NotNull().WithMessage("InventoryId can't be null")
                .GreaterThan(0).WithMessage("InventoryId must be greater than 0.")
                .MustAsync(async (inventoryId, cancellationToken) =>
                {
                    _inventorySpecification.Criteria = inventory => inventory.Id == inventoryId;
                    return (await _unitOfWork.Repository<Inventory>().FindAsNoTrackingAsync(_inventorySpecification)) is not null;
                }).WithMessage("InventoryId doesn't exists."); ;
        }

        public void DiscountIdValidator()
        {
            RuleFor(request => request.DiscountId)
                .NotEmpty().WithMessage("DiscountId can't be empty")
                .NotNull().WithMessage("DiscountId can't be null")
                .GreaterThan(0).WithMessage("DiscountId must be greater than 0.")
                .MustAsync(async (discountId, cancellationToken) =>
                {
                    _discountSpecification.Criteria = discount => discount.Id == discountId;
                    return (await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification)) is not null;
                }).WithMessage("DiscountId doesn't exists."); ;
        }

        #endregion Methods
    }
}