using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ConfirmEmail;
using ECommerceAPI.Application.DTOs.Authentication.ForgetPassword;
using ECommerceAPI.Application.DTOs.Authentication.ResetPassword;
using ECommerceAPI.Application.DTOs.Authentication.SignIn;
using ECommerceAPI.Application.DTOs.Authentication.SignUp;
using ECommerceAPI.Application.DTOs.Authentication.Token;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Application.Interfaces.Services.Mail;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Users;
using ECommerceAPI.Domain.Enumerations.Users;
using ECommerceAPI.Domain.IdentityEntities;
using ECommerceAPI.Shared.Helpers.MailConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;

namespace ECommerceAPI.Infrastructure.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Properties

        #region Constructors

        public AuthenticationService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IMailService mailService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Constructors

        #region Methods

        public async Task<SignUpDTOResponse> SignUpAsync(SignUpDTORequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);

            var mailUserName = new MailAddress(user.Email!).User;
            user.UserName = $"{mailUserName}-{user.Id}";

            // Create User
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new SignUpDTOResponse
                {
                    IsAuthenticated = false,
                    Message = "User creation failed."
                };
            }

            // Create UserProfile
            await _unitOfWork.Repository<UserProfile>().AddAsync(new UserProfile() { UserId = user.Id, Bio = string.Empty });

            // Assign Roles
            await _userManager.AddToRoleAsync(user, UserRole.Customer.ToString());

            // Build Confirmation Mail
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);
            var confirmationUrl = $"{_httpContextAccessor.HttpContext!.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/Api/V1/User/Authentication/ConfirmEmail?userId={user.Id}&token={encodedToken}";

            // Send Confirmation Mail
            var mailData = new MailData(
                mailUserName,
                user.Email!,
                "Confirm Your Email",
                $@"
                    <html>
                        <body>
                            <h2>Confirm Your Email</h2>
                            <p>Dear {mailUserName},</p>
                            <p>Please confirm your account by following this link: <a href='{HtmlEncoder.Default.Encode(confirmationUrl)}'>Confirm Email</a></p>
                            <p>Best regards,<br/>{mailUserName}</p>
                        </body>
                    </html>"
            );
            await _mailService.SendAsync(mailData);

            return new SignUpDTOResponse
            {
                IsAuthenticated = true,
                Message = "User created successfully. Please check your email to confirm your account."
            };
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

        public async Task<ConfirmEmailDTOResponse> ConfirmEmailAsync(ConfirmEmailDTORequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            var token = WebUtility.UrlDecode(request.Token).Replace(" ", "+");
            var result = await _userManager.ConfirmEmailAsync(user!, token);

            if (!result.Succeeded)
            {
                return new ConfirmEmailDTOResponse()
                {
                    IsAuthenticated = false,
                    Message = "Email Confirmation Failed!"
                };
            }

            return new ConfirmEmailDTOResponse()
            {
                IsAuthenticated = true,
                Message = "Email Confirmation Success."
            };
        }

        public async Task<ForgetPasswordDTOResponse> ForgetPasswordAsync(ForgetPasswordDTORequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            // Build Confirmation Mail
            var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
            var encodedToken = WebUtility.HtmlEncode(token);

            // Send Confirmation Mail
            var mailUserName = new MailAddress(user!.Email!).User;

            var mailData = new MailData(
                mailUserName,
                user.Email!,
                "Reset Your Password",
                $@"
                    <html>
                        <body>
                            <h2>Reset Your Password</h2>
                            <p>Dear {mailUserName},</p>
                            <p><b>UserId:</b> {user.Id}</p>
                            <p><b>Token:</b> {token}</p>
                            <br />
                            <p>Best regards,<br/>{mailUserName}</p>
                        </body>
                    </html>"
            );
            await _mailService.SendAsync(mailData);

            return new ForgetPasswordDTOResponse
            {
                Message = "Please check your email to reset your password."
            };
        }

        public async Task<ResetPasswordDTOResponse> ResetPasswordAsync(ResetPasswordDTORequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            var token = WebUtility.HtmlDecode(request.Token);
            var result = await _userManager.ResetPasswordAsync(user!, token, request.NewPassword);
            if (!result.Succeeded)
            {
                return new ResetPasswordDTOResponse()
                {
                    Message = "Reset Password Failed.",
                    IsAuthenticated = false,
                };
            }

            // Build Response
            return new ResetPasswordDTOResponse()
            {
                Message = "Reset Password Success.",
                IsAuthenticated = true,
            };
        }

        #endregion Methods
    }
}