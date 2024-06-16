using AutoMapper;
using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.DTOs;
using ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerceAPI.Application.Features.User.Profiles.Queries.GetProfileByUserAccessToken.Handlers
{
    public class GetProfileByUserAccessTokenQueryHandler : ResponseHandler, IRequestHandler<GetProfileByUserAccessTokenQueryRequest, Response<GetProfileByUserAccessTokenQueryDTO>>
    {
        #region Properties

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBaseSpecification<UserProfile> _profileSpecification;

        #endregion Properties

        #region Constructors

        public GetProfileByUserAccessTokenQueryHandler(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IBaseSpecification<UserProfile> profileSpecification)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _profileSpecification = profileSpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetProfileByUserAccessTokenQueryDTO>> Handle(GetProfileByUserAccessTokenQueryRequest request, CancellationToken cancellationToken)
        {
            // Get Token From Request Authorization Header
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader!.Substring($"{JwtBearerDefaults.AuthenticationScheme} ".Length).Trim();
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            // Get Email Claim From Token
            var email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            if (email == null)
                return Unauthorized<GetProfileByUserAccessTokenQueryDTO>();

            // Get User
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Forbidden<GetProfileByUserAccessTokenQueryDTO>();

            // Get User Profile
            _profileSpecification.Criteria = p => p.UserId == user.Id;
            var profile = await _unitOfWork.Repository<UserProfile>().FindAsNoTrackingAsync(_profileSpecification);

            // Map Response
            var response = _mapper.Map<GetProfileByUserAccessTokenQueryDTO>(profile);
            return Success(response);
        }

        #endregion Methods
    }
}