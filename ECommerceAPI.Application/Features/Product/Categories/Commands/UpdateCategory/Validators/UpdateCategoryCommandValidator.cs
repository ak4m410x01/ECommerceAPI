using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;

        #endregion Properties

        #region Constructors

        public UpdateCategoryCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            InitializeRules();
        }

        #endregion Constructors

        #region Methods

        private void InitializeRules()
        {
            IdValidator();
            NameValidator();
            DescriptionValidator();
            ParentCategoryIdValidator();
        }

        private void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Id == id && category.DeletedAt == null;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is not null;
                }).WithMessage("Category doesn't exists.");
        }

        private void NameValidator()
        {
            RuleFor(request => request.Name)
                .MustAsync(async (request, name, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Id != request.Id && category.Name == request.Name && category.DeletedAt == null;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is null;
                }).WithMessage("Name already exists.");
        }

        private void DescriptionValidator()
        {
            RuleFor(request => request.Description)
                .MaximumLength(2000).WithMessage("Description maximum length must be 2000.");
        }

        private void ParentCategoryIdValidator()
        {
            RuleFor(request => request.ParentCategoryId)
                .GreaterThan(0).WithMessage("ParentCategoryId must be greater than 0.")
                .NotEqual(request => request.Id).WithMessage("ParentCategoryId must not equal Id.")
                .MustAsync(async (parentCategoryId, cancellationToken) =>
                {
                    if (parentCategoryId == null) return true;

                    _categorySpecification.Criteria = category => category.Id == parentCategoryId && category.DeletedAt == null;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is not null;
                }).WithMessage("ParentCategoryId doesn't exists.");
        }

        #endregion Methods
    }
}