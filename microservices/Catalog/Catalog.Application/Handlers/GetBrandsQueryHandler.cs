using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _repository;
        private IMapper _mapper;
        public GetBrandsQueryHandler(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        } 

        public async Task<IList<BrandResponse>> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetProductBrandsAsync();

            // Map the brands to BrandResponse objects
            var brandResponses = _mapper.Map<IList<BrandResponse>>(brands);
            return brandResponses;
        }
    }
}