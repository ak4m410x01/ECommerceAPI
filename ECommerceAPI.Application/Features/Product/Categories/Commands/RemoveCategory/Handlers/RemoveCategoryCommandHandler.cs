using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.RemoveCategory.Handlers
{
    public class RemoveCategoryCommandHandler : ResponseHandler, IRequestHandler<RemoveCategoryCommandRequest, Response<RemoveCategoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Category> _categorySpecification;

        #endregion Properties

        #region Constructors

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork, IBaseSpecification<Category> categorySpecification)
        {
            _unitOfWork = unitOfWork;
            _categorySpecification = categorySpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<RemoveCategoryCommandDTO>> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            _categorySpecification.Criteria = category => category.Id == request.Id && category.DeletedAt == null;
            var category = await _unitOfWork.Repository<Category>().FindAsync(_categorySpecification);

            category!.Name = $"{category.Name}-Deleted-{Guid.NewGuid()}";
            await _unitOfWork.Repository<Category>().RemoveAsync(category!);

            return Removed<RemoveCategoryCommandDTO>();
        }

        #endregion Methods
    }
}