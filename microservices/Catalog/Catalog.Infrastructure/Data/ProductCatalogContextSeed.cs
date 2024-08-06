using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public static class ProductCatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollect)
        {
            bool productExists = productCollect.Find(p => true).Any();
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "products.json");

            if(!productExists)
            {
                var productsData = File.ReadAllText("../Catalog/Catalog.Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if(products != null)
                {
                    foreach(var product in products)
                    {
                        productCollect.InsertOneAsync(product);
                    }
                }    
            
            }
        }
    }
}