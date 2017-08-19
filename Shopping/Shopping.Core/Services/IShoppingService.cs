using Shopping.Core.POs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
