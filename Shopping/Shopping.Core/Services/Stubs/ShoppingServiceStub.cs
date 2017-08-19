using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Core.POs;

namespace Shopping.Core.Services.Stubs
{
    public class ShoppingServiceStub //: IShoppingService
    {
        //public List<ShoppingItemEntity> _shoppinglist = new List<ShoppingItemEntity>();

        //public ShoppingServiceStub()
        //{
        //    _shoppinglist = new List<ShoppingItemEntity>()
        //    {
        //        new ShoppingItemPerPcs()
        //        {
        //            ShoppingId = 1,
        //            ImgPath = "koszulka.jpg",
        //            Name = "Koszulka",
        //            Price = 154.99,
        //            ItemCount = 2
        //        },
        //        new ShoppingItemPerWeight()
        //        {
        //            ShoppingId = 2,
        //            ImgPath = "banany.jpg",
        //            Name = "Banany",
        //            Price = 7,
        //            ItemAmount = 0.5
        //        },
        //        new ShoppingItemPerPcs()
        //        {
        //            ShoppingId = 3,
        //            ImgPath = "sukienka.jpg",
        //            Name = "Sukienka",
        //            Price = 250,
        //            ItemCount = 1
        //        },
        //        new ShoppingItemPerWeight()
        //        {
        //            ShoppingId = 4,
        //            ImgPath = "arbuz.jpg",
        //            Name = "Arbuz",
        //            Price = 2.5,
        //            ItemAmount =1.5
        //        },
        //    };
        //}
        

        //public Task<ShoppingItemEntity> GetShoppingItem(int id)
        //{
        //    var item = _shoppinglist.Where(x => x.ShoppingId == id).FirstOrDefault();
        //    return Task.FromResult(item);
        //}

        //public Task<List<ShoppingItemEntity>> GetShoppingItems(string phrase)
        //{
        //    var items = _shoppinglist.Where(x => x.Name.StartsWith(phrase)).ToList();
        //    return Task.FromResult(items);
        //}

        //public Task<List<ShoppingItemEntity>> GetShoppingList()
        //{
        //    return Task.FromResult(_shoppinglist);
        //}

        //public Task<List<ShoppingItemEntity>> DeleteShoppingItem(ShoppingItemEntity item)
        //{
        //    _shoppinglist.Remove(item);
        //    return Task.FromResult(_shoppinglist);
        //}

        //public Task<List<ShoppingItemEntity>> EditShoppingItem(ShoppingItemEntity item)
        //{
        //    var currentItem = _shoppinglist.Where(x => x.ShoppingId == item.ShoppingId).FirstOrDefault();
        //    var index = _shoppinglist.IndexOf(currentItem);
        //    _shoppinglist[index] = item;
        //    return Task.FromResult(_shoppinglist);
        //}

        //public Task<List<ShoppingItemEntity>> AddShoppingItem(ShoppingItemEntity item)
        //{
        //    _shoppinglist.Add(item);
        //    return Task.FromResult(_shoppinglist);
        //}

        //public Task<List<ShoppingItemEntity>> ClearShoppingList()
        //{
        //    _shoppinglist.Clear();
        //    return Task.FromResult(_shoppinglist);
        //}
    }
}
