using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetCategoryById.Validators
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQueryRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;

        #endregion Properties

        #region Constructors

        public GetCategoryByIdQueryValidator(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            IdValidator();
        }

        #endregion Constructors

        #region Methods

        public void IdValidator()
        {
            RuleFor(request => request.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 1.")
                .MustAsync(async (id, cancellationToken) =>
                {
                    _categorySpecification.Criteria = category => category.Id == id;
                    return (await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification)) is not null;
                }).WithMessage("Category doesn't exists.");
        }

        #endregion Methods
    }
}