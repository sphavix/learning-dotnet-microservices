using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specifications;
using Catalog.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductCatalogRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly IProductCatalogContext _context;
        public ProductCatalogRepository(IProductCatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Product>> GetProductsAsync(CatalogSpecifications catalogSpecifications)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;

            if(!string.IsNullOrEmpty(catalogSpecifications.Search))
            {
                var searchFilter = builder.Regex(x => x.Name, new BsonRegularExpression(catalogSpecifications.Search));
                filter &= searchFilter;
            }

            if(!string.IsNullOrEmpty(catalogSpecifications.BrandId))
            {
                var brandFilter = builder.Regex(x => x.ProductBrand.Id, new BsonRegularExpression(catalogSpecifications.BrandId));
                filter &= brandFilter;
            }

            if(!string.IsNullOrEmpty(catalogSpecifications.TypeId))
            {
                var typesFilter = builder.Regex(x => x.ProductType.Id, new BsonRegularExpression(catalogSpecifications.TypeId));
                filter &= typesFilter;
            }

            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByBrandAsync(string brand)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ProductBrand.Name, brand);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _context.Products
                    .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.Brands.Find(b => true).ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _context.Types.Find(t => true).ToListAsync();
        }        
    }
}