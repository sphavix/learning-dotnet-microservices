using AutoMapper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _repository;
        
        public GetBrandsQueryHandler(IBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        } 

        public async Task<IList<BrandResponse>> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetProductBrandsAsync();

            // Map the brands to BrandResponse objects with Lazy Mapper. 
            //Using Lazy mapping we avoid loading our ctor with Automapper
            var brandResponses = ProductMapper.Mapper.Map<IList<BrandResponse>>(brands);
            return brandResponses;
        }
    }
}