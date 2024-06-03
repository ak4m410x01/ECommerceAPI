using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Queries.GetById.Handlers
{
    public class GetByIdQueryHandler : ResponseHandler, IRequestHandler<GetByIdQueryRequest, Response<GetByIdQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetByIdQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetByIdQueryDTO>> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _categorySpecification.Criteria = category => category.Id == request.Id;

            var category = await _unitOfWork.Repository<Category>().FindAsNoTrackingAsync(_categorySpecification);

            if (category is null)
            {
                return NotFound<GetByIdQueryDTO>("Category doesn't exists.");
            }

            var data = _mapper.Map<GetByIdQueryDTO>(category);
            return Success(data);
        }

        #endregion Methods
    }
}