using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Core.Model.Entities;

namespace Shopping.Core.Services
{
    public interface IShoppingService
    {
        Task<List<ShoppingItemEntity>> GetShoppingList();

        Task AddShoppingItem(ShoppingItemEntity item);

        Task EditShoppingItem(ShoppingItemEntity item);

        Task DeleteShoppingItem(ShoppingItemEntity item);

        Task ClearShoppingList();

        Task InitDatabase();
    }
}