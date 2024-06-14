using AutoMapper;
using ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.DTOs;
using ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.Requests;
using ECommerceAPI.Application.Interfaces.Services.Authentication;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.User.Authentications.Commands.GetRefreshToken.Handlers
{
    public class GetRefreshTokenCommandHandler : ResponseHandler, IRequestHandler<GetRefreshTokenCommandRequest, Response<GetRefreshTokenCommandDTO>>
    {
        #region Properties

        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetRefreshTokenCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetRefreshTokenCommandDTO>> Handle(GetRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await _authenticationService.GetRefreshTokenAsync(request.RefreshToken);
            var response = _mapper.Map<GetRefreshTokenCommandDTO>(refreshToken);
            return Success(response);
        }

        #endregion Methods
    }
}