using AutoMapper;
using ECommerceAPI.Application.Extensions.Responses;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Handlers
{
    public class GetAllCategoriesQueryHandler : ResponseHandler, IRequestHandler<GetAllCategoriesQueryRequest, PaginatedResponse<GetAllCategoriesQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<PaginatedResponse<GetAllCategoriesQueryDTO>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            _categorySpecification.Criteria = category => category.DeletedAt == null;
            var categories = await _unitOfWork.Repository<Category>().GetAllAsNoTrackingAsync(_categorySpecification);
            var data = _mapper.ProjectTo<GetAllCategoriesQueryDTO>(categories);

            var paginatedData = await data.ToPaginatedQueryableAsync(request.PageNumber, request.PageSize);
            return paginatedData;
        }

        #endregion Methods
    }
}