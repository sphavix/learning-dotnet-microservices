using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetBrandsQuery: IRequest<IList<BrandResponse>>
    {

    }
}