using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool brandExist = brandCollection.Find(x => true).Any();
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Data","SeedData", "brands.json");
            
            // check existing brand or insert a brand into the file
            if (!brandExist)
            {
                var brandsData = File.ReadAllText("../Catalog/Catalog.Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if(brands is not null)
                {
                    foreach (var brand in brands)
                    {
                        brandCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}