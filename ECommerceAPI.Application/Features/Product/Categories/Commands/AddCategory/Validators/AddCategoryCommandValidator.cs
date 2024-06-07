using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;

        #endregion Properties

        #region Constructors

        public AddCategoryCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            NameValidator();
            ParentCategoryIdValidator();
        }

        #endregion Constructors

        #region Methods

        public void NameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name can't be empty.")
                .NotNull().WithMessage("Name can't be null.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Name == name;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is null;
                }).WithMessage("Name already exists.");
        }

        public void ParentCategoryIdValidator()
        {
            RuleFor(request => request.ParentCategoryId)
                .NotEmpty().WithMessage("ParentCategoryId can't be empty.")
                .NotNull().WithMessage("ParentCategoryId can't be null.")
                .GreaterThan(0).WithMessage("ParentCategoryId must be greater than 0.")
                .MustAsync(async (parentCategoryId, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Id == parentCategoryId;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is not null;
                }).WithMessage("ParentCategoryId doesn't exists.");
        }

        #endregion Methods
    }
}