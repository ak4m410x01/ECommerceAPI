using AutoMapper;
using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.DTOs;
using ECommerceAPI.Application.Features.Product.Categories.Commands.Add.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Categories.Commands.Add.Handlers
{
    public class AddCommandHandler : ResponseHandler, IRequestHandler<AddCommandRequest, Response<AddCommandDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public AddCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<AddCommandDTO>> Handle(AddCommandRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _unitOfWork.Repository<Category>().AddAsync(category);

            var response = _mapper.Map<AddCommandDTO>(category);
            return Created(response);
        }

        #endregion Methods
    }
}