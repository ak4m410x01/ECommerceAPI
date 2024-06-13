using AutoMapper;
using ECommerceAPI.Application.Extensions.Responses;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.DTOs;
using ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.Requests;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Shared.Responses;
using MediatR;

namespace ECommerceAPI.Application.Features.Product.Tags.Queries.GetAllTags.Handlers
{
    public class GetAllTagsQueryHandler : ResponseHandler, IRequestHandler<GetAllTagsQueryRequest, PaginatedResponse<GetAllTagsQueryDTO>>
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBaseSpecification<Tag> _tagSpecification;

        #endregion Properties

        #region Constructors

        public GetAllTagsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IBaseSpecification<Tag> tagSpecification)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tagSpecification = tagSpecification;
        }

        #endregion Constructors

        #region Methods

        public async Task<PaginatedResponse<GetAllTagsQueryDTO>> Handle(GetAllTagsQueryRequest request, CancellationToken cancellationToken)
        {
            var tags = await _unitOfWork.Repository<Tag>().GetAllAsNoTrackingAsync(_tagSpecification);
            var data = _mapper.ProjectTo<GetAllTagsQueryDTO>(tags);

            var paginatedData = await data.ToPaginatedQueryableAsync(request.PageNumber, request.PageSize);
            return paginatedData;
        }

        #endregion Methods
    }
}