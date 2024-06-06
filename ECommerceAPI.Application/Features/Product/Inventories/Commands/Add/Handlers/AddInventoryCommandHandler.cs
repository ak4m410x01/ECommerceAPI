using AutoMapper;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.Add.Handlers
{
    public class AddInventoryCommandHandler : ResponseHandler, IRequestHandler<AddInventoryCommandRequest, Response<AddInventoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddInventoryCommandDTO>> Handle(AddInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);
            await _unitOfWork.Repository<Inventory>().AddAsync(inventory);
            var response = _mapper.Map<AddInventoryCommandDTO>(inventory);
            return Created(response);
        }

        #endregion Methods
    }
}