using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Core.POs;
using SQLite;
using Xamarin.Forms;

namespace Shopping.Core.Services.Production
{
    public class ShoppingService : IShoppingService
    { 
        readonly SQLiteAsyncConnection database;

        public ShoppingService()
        {
            //database = new SQLiteAsyncConnection(dbPath);
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTableAsync<ShoppingItemPO>().Wait();

            //if (!database.t) //.Table<ShoppingItemPO>().Any())
            //{
            //    AddNewCustomer();
            //}

            // add checking if emty table
            List<ShoppingItemPO> list = GetShoppinItems();
            foreach(var item in list)
            {
                AddShoppingItem(item);
            }
        }

        public List<ShoppingItemPO> GetShoppinItems()
        {
            return new List<ShoppingItemPO>()
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
        public Task<List<ShoppingItemPO>> AddShoppingItem(ShoppingItemPO item)
        {
            database.InsertAsync(item);
            return GetShoppingList();
        }

        // remove it
        public async Task<List<ShoppingItemPO>> ClearShoppingList()
        {
            var items = await GetShoppingList();
            foreach(var item in items)
            {
                await database.DeleteAsync(item);
            }
            return await GetShoppingList();
        }

        public Task<List<ShoppingItemPO>> DeleteShoppingItem(ShoppingItemPO item)
        {
            database.DeleteAsync(item);
            return GetShoppingList();
        }

        public Task<List<ShoppingItemPO>> EditShoppingItem(ShoppingItemPO item)
        {
            database.UpdateAsync(item);
            return GetShoppingList();
        }

        public Task<List<ShoppingItemPO>> GetShoppingList()
        {
            return database.Table<ShoppingItemPO>().ToListAsync();
        }
    }
}
