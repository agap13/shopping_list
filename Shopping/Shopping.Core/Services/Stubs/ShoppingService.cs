using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Core.POs;

namespace Shopping.Core.Services.Stubs
{
    public class ShoppingService : IShoppingService
    {
        public List<ShoppingItemPO> _shoppinglist = new List<ShoppingItemPO>();

        public ShoppingService()
        {
            _shoppinglist = new List<ShoppingItemPO>()
            {
                new ShoppingItemPerPcs()
                {
                    ShoppingId = 1,
                    ImgPath = "koszulka.jpg",
                    Name = "Koszulka",
                    Price = 154.99,
                    ItemCount = 2
                },
                new ShoppingItemPerWeight()
                {
                    ShoppingId = 2,
                    ImgPath = "banany.jpg",
                    Name = "Banany",
                    Price = 7,
                    ItemAmount = 0.5
                },
                new ShoppingItemPerPcs()
                {
                    ShoppingId = 3,
                    ImgPath = "sukienka.jpg",
                    Name = "Sukienka",
                    Price = 250,
                    ItemCount = 1
                },
                new ShoppingItemPerWeight()
                {
                    ShoppingId = 4,
                    ImgPath = "arbuz.jpg",
                    Name = "Arbuz",
                    Price = 2.5,
                    ItemAmount =1.5
                },
            };
        }
        

        public Task<ShoppingItemPO> GetShoppingItem(int id)
        {
            var item = _shoppinglist.Where(x => x.ShoppingId == id).FirstOrDefault();
            return Task.FromResult(item);
        }

        public Task<List<ShoppingItemPO>> GetShoppingItems(string phrase)
        {
            var items = _shoppinglist.Where(x => x.Name.StartsWith(phrase)).ToList();
            return Task.FromResult(items);
        }

        public Task<List<ShoppingItemPO>> GetShoppingList()
        {
            return Task.FromResult(_shoppinglist);
        }

        public Task<List<ShoppingItemPO>> DeleteShoppingItem(int id)
        {
            var item = _shoppinglist.Where(x => x.ShoppingId == id).FirstOrDefault();
            _shoppinglist.Remove(item);
            return Task.FromResult(_shoppinglist);
        }

        public Task<List<ShoppingItemPO>> EditShoppingItem(ShoppingItemPO item)
        {
            var currentItem = _shoppinglist.Where(x => x.ShoppingId == item.ShoppingId).FirstOrDefault();
            var index = _shoppinglist.IndexOf(currentItem);
            _shoppinglist[index] = item;
            return Task.FromResult(_shoppinglist);
        }

        public Task<List<ShoppingItemPO>> AddShoppingItem(ShoppingItemPO item)
        {
            _shoppinglist.Add(item);
            return Task.FromResult(_shoppinglist);
        }
    }
}
