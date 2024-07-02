using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteProductByIdQueryHandler : IRequestHandler<DeleteProductByIdQuery, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteProductAsync(query.Id);
        }
    }
}