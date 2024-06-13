using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Validators
{
    public class AddTagCommandValidator : AbstractValidator<AddTagCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Tag> _tagSpecification;

        #endregion Properties

        #region Constructors

        public AddTagCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<Tag> tagSpecification)
        {
            _unitOfWork = unitOfWork;
            _tagSpecification = tagSpecification;
            NameValidator();
        }

        #endregion Constructors

        #region Methods

        public void NameValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .NotNull().WithMessage("Name can't be null")
                .MustAsync(async (name, cancellationToken) =>
                {
                    _tagSpecification.Criteria = tag => tag.Name == name;
                    return (await _unitOfWork.Repository<Tag>().FindAsNoTrackingAsync(_tagSpecification)) is null;
                }).WithMessage("Name already exists.");
        }

        #endregion Methods
    }
}