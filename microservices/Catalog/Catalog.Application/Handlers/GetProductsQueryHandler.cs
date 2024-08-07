using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specifications;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Pagination<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Pagination<ProductResponse>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsAsync(query._catalogSpecifications);

            // Map the brands to BrandResponse objects with Lazy Mapper. 
            //Using Lazy mapping we avoid loading our ctor with Automapper
            var productResponse = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(products);
            return productResponse;
        }
    }
}