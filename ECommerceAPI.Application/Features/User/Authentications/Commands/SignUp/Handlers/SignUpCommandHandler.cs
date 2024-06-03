using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.SignUp.Handlers
{
    public class SignUpCommandHandler : ResponseHandler, IRequestHandler<SignUpCommandRequest, Response<SignUpCommandDTO>>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public SignUpCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<Response<SignUpCommandDTO>> Handle(SignUpCommandRequest request, CancellationToken cancellationToken)
        {
            var signUpDto = _mapper.Map<SignUpDTO>(request);

            var authenticationResponse = await _authenticationService.SignUpAsync(signUpDto);

            var response = _mapper.Map<SignUpCommandDTO>(authenticationResponse);

            return response.IsAuthenticated ? Success(response) : BadRequest<SignUpCommandDTO>(response.Message);
        }
    }
}