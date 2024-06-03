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

        public Task<AuthenticationResponseDTO> SignInAsync(SignInDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResponseDTO> SignUpAsync(SignUpDTO dto)
        {
            // Check if Email Exists
            if (_userManager.FindByEmailAsync(dto.Email) is null)
            {
                return await Task.FromResult(new AuthenticationResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = "Email already exists."
                });
            }

            // Check if UserName Exits
            if (_userManager.FindByNameAsync(dto.UserName) is null)
            {
                return await Task.FromResult(new AuthenticationResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = "UserName already exists."
                });
            }

            var user = _mapper.Map<ApplicationUser>(dto);

            // Create User
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                return await Task.FromResult(new AuthenticationResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = error is null ? "Something wrong." : error.Description
                });
            }

            // Assign Roles
            await _userManager.AddToRoleAsync(user, UserRole.Customer.ToString());
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault();
                return await Task.FromResult(new AuthenticationResponseDTO()
                {
                    IsAuthenticated = false,
                    Message = error is null ? "Something wrong." : error.Description
                });
            }

            // Generate Token
            var token = await _tokenService.CreateTokenAsync(user);

            // Get User Roles
            var roles = await _userManager.GetRolesAsync(user);

            // Build Response
            var response = _mapper.Map<AuthenticationResponseDTO>(user);
            response.Roles = roles;
            response.IsAuthenticated = true;
            response.AccessToken = token.value;
            response.AccessTokenValidTo = token.validTo;

            return response;
        }

        #endregion Methods
    }
}