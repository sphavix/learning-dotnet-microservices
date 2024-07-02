using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypeRepository _typeRepository;
        public GetTypesQueryHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IList<TypesResponse>> Handle(GetTypesQuery query, CancellationToken cancellationToken)
        {
            var productTypes = await _typeRepository.GetProductTypesAsync();

            // Map the brands to BrandResponse objects with Lazy Mapper. 
            //Using Lazy mapping we avoid loading our ctor with Automapper.
            var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(productTypes);
            return typesResponse;
        }
    }
}