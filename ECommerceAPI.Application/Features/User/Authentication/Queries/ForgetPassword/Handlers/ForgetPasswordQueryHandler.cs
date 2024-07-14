using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ForgetPassword;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ForgetPassword.Handlers
{
    public class ForgetPasswordQueryHandler : ResponseHandler, IRequestHandler<ForgetPasswordQueryRequest, Response<ForgetPasswordQueryDTO>>
    {
        #region Properties

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public ForgetPasswordQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<ForgetPasswordQueryDTO>> Handle(ForgetPasswordQueryRequest request, CancellationToken cancellationToken)
        {
            var forgetPasswordDTORequest = _mapper.Map<ForgetPasswordDTORequest>(request);
            var forgetPasswordDTOResponse = await _authenticationService.ForgetPasswordAsync(forgetPasswordDTORequest);

            var response = _mapper.Map<ForgetPasswordQueryDTO>(forgetPasswordDTOResponse);
            return Success(response);
        }

        #endregion Methods
    }
}