using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.UpdateDiscount.Handlers
{
    public class UpdateDiscountCommandHandler : ResponseHandler, IRequestHandler<UpdateDiscountCommandRequest, Response<UpdateDiscountCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public UpdateDiscountCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<UpdateDiscountCommandDTO>> Handle(UpdateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            _discountSpecification.Criteria = dsc => dsc.Id == request.Id && dsc.DeletedAt == null;
            var discount = await _unitOfWork.Repository<Discount>().FindAsync(_discountSpecification);
            _mapper.Map(request, discount);
            discount!.ModifiedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Discount>().UpdateAsync(discount!);
            var response = _mapper.Map<UpdateDiscountCommandDTO>(discount);
            return Success(response);
        }

        #endregion Methods
    }
}