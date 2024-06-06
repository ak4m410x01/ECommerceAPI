using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Requests;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.AddCategory.Handlers
{
    public class AddCategoryCommandHandler : ResponseHandler, IRequestHandler<AddCategoryCommandRequest, Response<AddCategoryCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddCategoryCommandDTO>> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _unitOfWork.Repository<Category>().AddAsync(category);

            var response = _mapper.Map<AddCategoryCommandDTO>(category);
            return Created(response);
        }

        #endregion Methods
    }
}