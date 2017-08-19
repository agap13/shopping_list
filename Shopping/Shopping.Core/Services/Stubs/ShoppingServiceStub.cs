using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Core.Model.Entities;

namespace Shopping.Core.Services.Stubs
{
    public class ShoppingServiceStub : IShoppingService
    {
        private List<ShoppingItemEntity> _shoppinglist = new List<ShoppingItemEntity>();

        public ShoppingServiceStub()
        {
            _shoppinglist = new List<ShoppingItemEntity>
            {
                new ShoppingItemPerPcs
                {
                    ShoppingId = 1,
                    ImgPath = "koszulka.jpg",
                    Name = "Koszulka",
                    Price = 154.99,
                    ItemCount = 2
                },
                new ShoppingItemPerWeight
                {
                    ShoppingId = 2,
                    ImgPath = "banany.jpg",
                    Name = "Banany",
                    Price = 7,
                    ItemAmount = 0.5
                },
                new ShoppingItemPerPcs
                {
                    ShoppingId = 3,
                    ImgPath = "sukienka.jpg",
                    Name = "Sukienka",
                    Price = 250,
                    ItemCount = 1
                },
                new ShoppingItemPerWeight
                {
                    ShoppingId = 4,
                    ImgPath = "arbuz.jpg",
                    Name = "Arbuz",
                    Price = 2.5,
                    ItemAmount = 1.5
                }
            };
        }

        public Task<List<ShoppingItemEntity>> GetShoppingList()
        {
            return Task.FromResult(_shoppinglist);
        }

        public Task AddShoppingItem(ShoppingItemEntity item)
        {
            return Task.Run(() => _shoppinglist.Add(item));
        }

        public Task EditShoppingItem(ShoppingItemEntity item)
        {
            return Task.Run(() =>
            {
                var currentItem = _shoppinglist.FirstOrDefault(x => x.ShoppingId == item.ShoppingId);
                var index = _shoppinglist.IndexOf(currentItem);
                _shoppinglist[index] = item;
            });
        }

        public Task DeleteShoppingItem(ShoppingItemEntity item)
        {
            return Task.Run(() => { _shoppinglist.Remove(item); });
        }

        public Task ClearShoppingList()
        {
            return Task.Run(() => { _shoppinglist.Clear(); });
        }

        public Task InitDatabase()
        {
            return Task.Run(() => { });
        }
    }
}