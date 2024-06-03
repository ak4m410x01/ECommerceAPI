using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Queries.SignIn.Handlers
{
    public class SignInQueryHandler : ResponseHandler, IRequestHandler<SignInQueryRequest, Response<SignInQueryDTO>>
    {
        #region Properties

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public SignInQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<SignInQueryDTO>> Handle(SignInQueryRequest request, CancellationToken cancellationToken)
        {
            var signInDto = _mapper.Map<SignInDTO>(request);

            var authenticationResponse = await _authenticationService.SignInAsync(signInDto);

            var response = _mapper.Map<SignInQueryDTO>(authenticationResponse);

            return response.IsAuthenticated ? Success(response) : BadRequest<SignInQueryDTO>(response.Message);
        }

        #endregion Methods
    }
}