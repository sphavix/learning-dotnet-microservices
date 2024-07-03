using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdQuery, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductByIdQuery command, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteProductAsync(command.Id);
        }
    }
}