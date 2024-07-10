using ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.RemoveDiscount.Handlers
{
    public class RemoveDiscountCommandHandler : ResponseHandler, IRequestHandler<RemoveDiscountCommandRequest, Response<RemoveDiscountCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;

        #endregion Properties

        #region Constructors

        public RemoveDiscountCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<RemoveDiscountCommandDTO>> Handle(RemoveDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            _discountSpecification.Criteria = discount => discount.Id == request.Id && discount.DeletedAt == null;
            var discount = await _unitOfWork.Repository<Discount>().FindAsync(_discountSpecification);

            discount!.Code = $"{discount.Code}-Deleted-{Guid.NewGuid()}";
            await _unitOfWork.Repository<Discount>().RemoveAsync(discount!);

            return Removed<RemoveDiscountCommandDTO>();
        }

        #endregion Methods
    }
}