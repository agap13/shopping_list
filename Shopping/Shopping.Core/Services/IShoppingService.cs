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
        Task<List<ShoppingItemPO>> GetShoppingList();
        Task<ShoppingItemPO> GetShoppingItem(int id);
        Task<List<ShoppingItemPO>> AddShoppingItem(ShoppingItemPO item);
        Task<List<ShoppingItemPO>> EditShoppingItem(ShoppingItemPO item);
        Task<List<ShoppingItemPO>> DeleteShoppingItem(int id);
        Task<List<ShoppingItemPO>> GetShoppingItems(string phrase); // to search
    }
}
