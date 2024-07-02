using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsQuery : IRequest<IList<ProductResponse>>
    {
        
    }

}