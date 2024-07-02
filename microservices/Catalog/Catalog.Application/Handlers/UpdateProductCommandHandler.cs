using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.UpdateProductAsync(new Product
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                ImageFile = command.ImageFile,
                Summary = command.Summary,
                ProductBrand = command.ProductBrand,
                ProductType = command.ProductType
            });

            return product;
        }
    }
}