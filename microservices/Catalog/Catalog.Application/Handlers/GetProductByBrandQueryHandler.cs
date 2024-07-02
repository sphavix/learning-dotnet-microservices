using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandQueryHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByBrandQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByBrandAsync(query.Brand);
            var productResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(product);
            return productResponse;
        }
    }
}