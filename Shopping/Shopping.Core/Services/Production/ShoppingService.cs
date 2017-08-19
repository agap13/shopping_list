using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Core.POs;
using SQLite;
using Xamarin.Forms;
using Shopping.Core.Model.Storage.Interfaces;

namespace Shopping.Core.Services.Production
{
    public class ShoppingService : IShoppingService
    {
        private readonly IGenericStorage _genericStorage;

        public ShoppingService(IGenericStorage genericStorage)
        {
            _genericStorage = genericStorage;
        }
        public async Task AddShoppingItem(ShoppingItemEntity item)
        {
            if(item is ShoppingItemPerPcs)
                await _genericStorage.InsertRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.InsertRow(item as ShoppingItemPerWeight);
        }

        public async Task ClearShoppingList()
        {
            var shoppingListPerWeight = await _genericStorage.GetRows<ShoppingItemPerWeight>();
            var shoppingListPerPcs = await _genericStorage.GetRows<ShoppingItemPerPcs>();
            await _genericStorage.DeleteAll(shoppingListPerWeight);
            await _genericStorage.DeleteAll(shoppingListPerPcs);
        }

        public async Task DeleteShoppingItem(ShoppingItemEntity item)
        {
            if (item is ShoppingItemPerPcs)
                await _genericStorage.DeleteRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.DeleteRow(item as ShoppingItemPerWeight);
        }

        public async Task EditShoppingItem(ShoppingItemEntity item)
        {
            if (item is ShoppingItemPerPcs)
                await _genericStorage.InsertOrReplaceRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.InsertOrReplaceRow(item as ShoppingItemPerWeight);
        }

        public async Task<List<ShoppingItemEntity>> GetShoppingList()
        {
            var listPerPcs=(await _genericStorage.GetRows<ShoppingItemPerPcs>()).ToList();
            var listPerWeight = (await _genericStorage.GetRows<ShoppingItemPerWeight>()).ToList();

            List<ShoppingItemEntity> list = new List<ShoppingItemEntity>(listPerPcs);
            list.AddRange(listPerWeight);
            
            return new List<ShoppingItemEntity>(list);
        }

        public async Task InitDatabase()
        {        
            var shoppinglist = new List<ShoppingItemEntity>()
            {
                new ShoppingItemPerPcs()
                {
                    ImgPath = "koszulka.jpg",
                    Name = "Koszulka",
                    Price = 154.99,
                    ItemCount = 2
                },
                new ShoppingItemPerWeight()
                {
                    ImgPath = "banany.jpg",
                    Name = "Banany",
                    Price = 7,
                    ItemAmount = 0.5
                },
                new ShoppingItemPerPcs()
                {
                    ImgPath = "sukienka.jpg",
                    Name = "Sukienka",
                    Price = 250,
                    ItemCount = 1
                },
                new ShoppingItemPerWeight()
                {
                    ImgPath = "arbuz.jpg",
                    Name = "Arbuz",
                    Price = 2.5,
                    ItemAmount =1.5
                },
            };
            await _genericStorage.InsertRows<ShoppingItemPerPcs>(shoppinglist.OfType<ShoppingItemPerPcs>());
            await _genericStorage.InsertRows<ShoppingItemPerWeight>(shoppinglist.OfType<ShoppingItemPerWeight>());
        }
        
    }
}
