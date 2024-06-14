using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.SignIn;
using ECommerceAPI.Application.DTOs.Authentication.SignUp;
using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace ECommerceAPI.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<RefreshToken> _refreshTokenSpecification;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AuthenticationService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IBaseSpecification<RefreshToken> refreshTokenSpecification)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _refreshTokenSpecification = refreshTokenSpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<SignUpDTOResponse> SignUpAsync(SignUpDTORequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);

            user.UserName = $"{(new MailAddress(user.Email!)).User}-{user.Id}";

            // Create User
            await _userManager.CreateAsync(user, request.Password);

            // Assign Roles
            await _userManager.AddToRoleAsync(user, UserRole.Customer.ToString());

            return new SignUpDTOResponse();
        }

        public async Task<SignInDTOResponse> SignInAsync(SignInDTORequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return await Task.FromResult(new SignInDTOResponse()
                {
                    IsAuthenticated = false,
                    Message = "Invalid SignIn."
                });
            }

            // Build Response
            return new SignInDTOResponse()
            {
                Message = "SignIn Successfully",
                IsAuthenticated = true,
                AccessToken = await _tokenService.GenerateAccessTokenAsync(user),
                RefreshToken = await _tokenService.GenerateRefreshTokenAsync(user),
            };
        }

        public async Task<AccessTokenDTO> GetAccessTokenAsync(string refreshToken)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(user => user.RefreshTokens.Any(r => r.Token == refreshToken));

            return await _tokenService.GenerateAccessTokenAsync(user!);
        }

        public async Task<RefreshTokenDTO> GetRefreshTokenAsync(string refreshToken)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(user => user.RefreshTokens.Any(r => r.Token == refreshToken));

            return await _tokenService.GenerateRefreshTokenAsync(user!, true);
        }

        #endregion Methods
    }
}