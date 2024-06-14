using ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using FluentValidation;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.Validators
{
    public class GetRefreshTokenCommandValidator : AbstractValidator<GetRefreshTokenCommandRequest>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<RefreshToken> _refreshTokenSpecification;

        #endregion Properties

        #region Constructors

        public GetRefreshTokenCommandValidator(IUnitOfWork unitOfWork, IBaseSpecification<RefreshToken> refreshTokenSpecification)
        {
            _unitOfWork = unitOfWork;
            _refreshTokenSpecification = refreshTokenSpecification;
            RefreshTokenValidator();
        }

        #endregion Constructors

        #region Methods

        private void RefreshTokenValidator()
        {
            RuleFor(request => request.RefreshToken)
                .NotEmpty().WithMessage("Email can't be empty.")
                .NotNull().WithMessage("Email can't be null.")
                .MustAsync(async (token, cancellationToken) =>
                {
                    _refreshTokenSpecification.Criteria = r => r.Token == token;
                    var refreshToken = await _unitOfWork.Repository<RefreshToken>().FindAsNoTrackingAsync(_refreshTokenSpecification);
                    return refreshToken is not null && refreshToken.IsActive;
                }).WithMessage("Refresh Token is Expired or InValid.");
        }

        #endregion Methods
    }
}