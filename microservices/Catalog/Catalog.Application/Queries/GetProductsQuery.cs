using Catalog.Application.Responses;
using Catalog.Core.Specifications;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsQuery : IRequest<Pagination<ProductResponse>>
    {
        public CatalogSpecifications _catalogSpecifications{ get; set; }

        public GetProductsQuery(CatalogSpecifications catalogSpecifications)
        {
            _catalogSpecifications = catalogSpecifications;
        }
    }

}