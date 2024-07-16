using Basket.Core.Entities;

namespace Basket.Core.Repositories
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShoppingCartAsync(string userName);
        Task<ShoppingCart> UpdateShoppingCartAsync();
        Task DeleteShoppingCart (string userName);
    }
}