using AutoMapper;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Commands.AddTag.Handlers
{
    public class AddTagCommandHandler : ResponseHandler, IRequestHandler<AddTagCommandRequest, Response<AddTagCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddTagCommandDTO>> Handle(AddTagCommandRequest request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Tag>(request);
            await _unitOfWork.Repository<Tag>().AddAsync(tag);

            var response = _mapper.Map<AddTagCommandDTO>(tag);
            return Created(response);
        }

        #endregion Methods
    }
}