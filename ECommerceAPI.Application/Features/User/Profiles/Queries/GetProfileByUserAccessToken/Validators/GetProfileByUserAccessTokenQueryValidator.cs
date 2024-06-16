using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Requests;
using FluentValidation;

namespace ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Validators
{
    public class GetProfileByUserAccessTokenQueryValidator : AbstractValidator<GetProfileByUserAccessTokenQueryRequest>
    {
        #region Constructors

        public GetProfileByUserAccessTokenQueryValidator()
        {
        }

        #endregion Constructors
    }
}