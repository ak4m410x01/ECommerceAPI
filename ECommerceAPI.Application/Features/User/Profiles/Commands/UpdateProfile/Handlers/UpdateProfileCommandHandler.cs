using AutoMapper;
using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.DTOs;
using ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Requests;
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

namespace ECommerceAPI.Application.Features.User.Profiles.Commands.UpdateProfile.Handlers
{
    public class UpdateProfileCommandHandler : ResponseHandler, IRequestHandler<UpdateProfileCommandRequest, Response<UpdateProfileCommandDTO>>
    {
        #region Properties

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        #endregion Properties

        #region Constructors

        public UpdateProfileCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<UpdateProfileCommandDTO>> Handle(UpdateProfileCommandRequest request, CancellationToken cancellationToken)
        {
            // Get Token From Request Authorization Header
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader!.Substring($"{JwtBearerDefaults.AuthenticationScheme} ".Length).Trim();
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            // Get Email Claim From Token
            var email = jwtToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;
            if (email == null)
                return Unauthorized<UpdateProfileCommandDTO>();

            // Get User
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Forbidden<UpdateProfileCommandDTO>();

            // Update User
            _mapper.Map(request, user);
            await _userManager.UpdateAsync(user);

            var response = _mapper.Map<UpdateProfileCommandDTO>(user);
            return Success(response, "Updated Successfully");
        }

        #endregion Methods
    }
}