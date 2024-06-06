using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AuthenticationService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<AuthenticationResponseDTO> SignInAsync(SignInDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return await Task.FromResult(new AuthenticationResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = "Invalid SignIn."
                });
            }

            // Generate Token
            var token = await _tokenService.CreateTokenAsync(user);

            // Build Response
            var response = new AuthenticationResponseDTO()
            {
                Message = "SignIn Successfully",
                IsAuthenticated = true,
                AccessToken = token.value,
                AccessTokenValidTo = token.validTo
            };

            return response;
        }

        public async Task<AuthenticationResponseDTO> SignUpAsync(SignUpDTO dto)
        {
            var user = _mapper.Map<ApplicationUser>(dto);

            // Create User
            await _userManager.CreateAsync(user, dto.Password);

            // Assign Roles
            await _userManager.AddToRoleAsync(user, UserRole.Customer.ToString());

            // Generate Token
            var token = await _tokenService.CreateTokenAsync(user);

            // Build Response
            var response = new AuthenticationResponseDTO()
            {
                Message = "SignUp Successfully",
                IsAuthenticated = true,
                AccessToken = token.value,
                AccessTokenValidTo = token.validTo
            };

            return response;
        }

        #endregion Methods
    }
}