using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.SignUp;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Commands.SignUp.Handlers
{
    public class SignUpCommandHandler : ResponseHandler, IRequestHandler<SignUpCommandRequest, Response<SignUpCommandDTO>>
    {
        #region Properties

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public SignUpCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<SignUpCommandDTO>> Handle(SignUpCommandRequest request, CancellationToken cancellationToken)
        {
            var signUpDTORequest = _mapper.Map<SignUpDTORequest>(request);
            var signUpDTOResponse = await _authenticationService.SignUpAsync(signUpDTORequest);
            var signUpCommandDTO = _mapper.Map<SignUpCommandDTO>(signUpDTOResponse);

            var response = Created(signUpCommandDTO);
            response.Message = "SignUp Successfully.";

            return response;
        }

        #endregion Methods
    }
}