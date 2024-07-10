using AutoMapper;
using ECommerceAPI.Application.Extensions.Responses;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs;
using ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.Handlers
{
    public class GetAllDiscountsQueryHandler : ResponseHandler, IRequestHandler<GetAllDiscountsQueryRequest, PaginatedResponse<GetAllDiscountsQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Discount> _discountSpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetAllDiscountsQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Discount> discountSpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _discountSpecification = discountSpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<PaginatedResponse<GetAllDiscountsQueryDTO>> Handle(GetAllDiscountsQueryRequest request, CancellationToken cancellationToken)
        {
            _discountSpecification.Criteria = discount => discount.DeletedAt == null;
            var discounts = await _unitOfWork.Repository<Discount>().GetAllAsNoTrackingAsync(_discountSpecification);
            var data = _mapper.ProjectTo<GetAllDiscountsQueryDTO>(discounts);

            var paginatedData = await data.ToPaginatedQueryableAsync(request.PageNumber, request.PageSize);
            return paginatedData;
        }

        #endregion Methods
    }
}