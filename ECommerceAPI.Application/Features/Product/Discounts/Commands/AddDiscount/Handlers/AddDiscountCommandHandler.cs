using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.Handlers
{
    public class AddDiscountCommandHandler : ResponseHandler, IRequestHandler<AddDiscountCommandRequest, Response<AddDiscountCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddDiscountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddDiscountCommandDTO>> Handle(AddDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            var discount = _mapper.Map<Discount>(request);
            await _unitOfWork.Repository<Discount>().AddAsync(discount);

            var response = _mapper.Map<AddDiscountCommandDTO>(discount);
            return Created(response);
        }

        #endregion Methods
    }
}