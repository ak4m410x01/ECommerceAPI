using AutoMapper;
using ECommerceAPI.Application.DTOs.Authentication.ResetPassword;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.DTOs;
using ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentication.Queries.ResetPassword.Handlers
{
    public class ResetPasswordQueryHandler : ResponseHandler, IRequestHandler<ResetPasswordQueryRequest, Response<ResetPasswordQueryDTO>>
    {
        #region Properties

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public ResetPasswordQueryHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<ResetPasswordQueryDTO>> Handle(ResetPasswordQueryRequest request, CancellationToken cancellationToken)
        {
            var resetPasswordDTORequest = _mapper.Map<ResetPasswordDTORequest>(request);
            var resetPasswordDTOResponse = await _authenticationService.ResetPasswordAsync(resetPasswordDTORequest);

            var response = _mapper.Map<ResetPasswordQueryDTO>(resetPasswordDTOResponse);
            return Success(response);
        }

        #endregion Methods
    }
}