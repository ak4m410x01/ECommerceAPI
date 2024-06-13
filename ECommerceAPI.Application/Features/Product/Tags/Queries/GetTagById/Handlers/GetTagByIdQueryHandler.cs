using AutoMapper;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Queries.GetTagById.Handlers
{
    public class GetTagByIdQueryHandler : ResponseHandler, IRequestHandler<GetTagByIdQueryRequest, Response<GetTagByIdQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseSpecification<Tag> _tagSpecification;
        private readonly IMapper _mapper;

        #endregion Properties

        #region Constructors

        public GetTagByIdQueryHandler(IUnitOfWork unitOfWork, IBaseSpecification<Tag> tagSpecification, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tagSpecification = tagSpecification;
            _mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        public async Task<Response<GetTagByIdQueryDTO>> Handle(GetTagByIdQueryRequest request, CancellationToken cancellationToken)
        {
            _tagSpecification.Criteria = tag => tag.Id == request.Id;
            var tag = await _unitOfWork.Repository<Tag>().FindAsNoTrackingAsync(_tagSpecification);
            var data = _mapper.Map<GetTagByIdQueryDTO>(tag);
            return Success(data);
        }

        #endregion Methods
    }
}