using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetAllCategories.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, IQueryable<GetAllCategoriesQueryDTO>>
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

        public async Task<IQueryable<GetAllCategoriesQueryDTO>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Category> categories = await _unitOfWork.Repository<Category>().GetAllAsync(_categorySpecification);
            return _mapper.ProjectTo<GetAllCategoriesQueryDTO>(categories);
        }

        #endregion Methods
    }
}