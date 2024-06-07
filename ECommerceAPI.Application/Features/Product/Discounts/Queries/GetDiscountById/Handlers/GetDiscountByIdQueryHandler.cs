using AutoMapper;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetDiscountById.Handlers
{
    public class GetDiscountByIdQueryHandler : ResponseHandler, IRequestHandler<GetDiscountByIdQueryRequest, Response<GetDiscountByIdQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetDiscountByIdQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetDiscountByIdQueryDTO>> Handle(GetDiscountByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _discountSpecification.Criteria = discount => discount.Id == request.Id;
            var discount = await _unitOfWork.Repository<Discount>().FindAsNoTrackingAsync(_discountSpecification);

            var data = _mapper.Map<GetDiscountByIdQueryDTO>(discount);
            return Success(data);
        }

        #endregion Methods
    }
}