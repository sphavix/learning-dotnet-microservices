using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typesCollection)
        {
            bool typeExist = typesCollection.Find(x => true).Any();
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Data","SeedData", "types.json");
            
            // check existing brand or insert a brand into the file
            if (!typeExist)
            {
                var typesData = File.ReadAllText("../Catalog/Catalog.Infrastructure/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if(productTypes is not null)
                {
                    foreach (var productType in productTypes)
                    {
                        typesCollection.InsertOneAsync(productType);
                    }
                }
            }
        }
    }
}