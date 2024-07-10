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
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            NameValidator();
            DescriptionValidator();
            ParentCategoryIdValidator();
        }

        public void NameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name is required field.")
                .NotNull().WithMessage("Name must be not null.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Name == name && category.DeletedAt == null;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is null;
                }).WithMessage("Name already exists.");
        }

        private void DescriptionValidator()
        {
            RuleFor(request => request.Description)
                .MaximumLength(2000).WithMessage("Description maximum length must be 2000.");
        }

        public void ParentCategoryIdValidator()
        {
            RuleFor(request => request.ParentCategoryId)
                .GreaterThan(0).WithMessage("ParentCategoryId must be greater than 0.")
                .MustAsync(async (parentCategoryId, cancellationToken) =>
                {
                    if (parentCategoryId == null) return true;

                    _categorySpecification.Criteria = category => category.Id == parentCategoryId && category.DeletedAt == null;
                    return await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification) is not null;
                }).WithMessage("ParentCategoryId doesn't exists.");
        }

        #endregion Methods
    }
}