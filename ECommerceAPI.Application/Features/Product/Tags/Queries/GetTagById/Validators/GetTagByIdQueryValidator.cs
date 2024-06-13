using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Validators
{
    public class GetTagByIdQueryValidator : AbstractValidator<GetTagByIdQueryRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Tag> _tagSpecification;

        #endregion Properties

        #region Constructors

        public GetTagByIdQueryValidator(IUnitOfWork unitOfWork, IBaseSpecification<Tag> tagSpecification)
        {
            _unitOfWork = unitOfWork;
            _tagSpecification = tagSpecification;
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
                    _tagSpecification.Criteria = tag => tag.Id == id;
                    return (await _unitOfWork.Repository<Tag>().FindAsNoTrackingAsync(_tagSpecification)) is not null;
                }).WithMessage("Product doesn't exists.");
        }

        #endregion Methods
    }
}