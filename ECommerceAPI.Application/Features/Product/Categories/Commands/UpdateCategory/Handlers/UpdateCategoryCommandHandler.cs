using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.UpdateCategory.Handlers
{
    public class UpdateCategoryCommandHandler : ResponseHandler, IRequestHandler<UpdateCategoryCommandRequest, Response<UpdateCategoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<UpdateCategoryCommandDTO>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            _categorySpecification.Criteria = ctg => ctg.Id == request.Id && ctg.DeletedAt == null;
            var category = await _unitOfWork.Repository<Category>().FindAsync(_categorySpecification);
            _mapper.Map(request, category);
            category!.ModifiedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Category>().UpdateAsync(category!);
            var response = _mapper.Map<UpdateCategoryCommandDTO>(category);
            return Created(response);
        }

        #endregion Methods
    }
}