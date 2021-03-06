﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Core.Model.Entities;
using Shopping.Core.Model.Storage.Interfaces;

namespace Shopping.Core.Services.Production
{
    /// <summary>
    /// Implemnetation of CRUD operation for ShoppingItemEntries.
    /// </summary>
    public class ShoppingService : IShoppingService
    {
        private readonly IGenericStorage _genericStorage;

        public ShoppingService(IGenericStorage genericStorage)
        {
            _genericStorage = genericStorage;
        }

        /// <summary>
        /// Async method for adding new ShoppingItemEntry to database.
        /// </summary>
        /// <param name="item">New Shopping item</param>
        /// <returns>Return task</returns>
        public async Task AddShoppingItem(ShoppingItemEntity item)
        {
            if (item is ShoppingItemPerPcs)
                await _genericStorage.InsertRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.InsertRow(item as ShoppingItemPerWeight);
        }

        /// <summary>
        /// Remove all shopping items from database.
        /// </summary>
        /// <returns>Return task</returns>
        public async Task ClearShoppingList()
        {
            var shoppingListPerWeight = await _genericStorage.GetRows<ShoppingItemPerWeight>();
            var shoppingListPerPcs = await _genericStorage.GetRows<ShoppingItemPerPcs>();
            await _genericStorage.DeleteAll(shoppingListPerWeight);
            await _genericStorage.DeleteAll(shoppingListPerPcs);
        }

        /// <summary>
        /// Delete shopping item entry from database.
        /// </summary>
        /// <param name="item">Item which should be deleted.</param>
        /// <returns>Return task.</returns>
        public async Task DeleteShoppingItem(ShoppingItemEntity item)
        {
            if (item is ShoppingItemPerPcs)
                await _genericStorage.DeleteRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.DeleteRow(item as ShoppingItemPerWeight);
        }

        /// <summary>
        /// Edit existing item and save modification in database.
        /// </summary>
        /// <param name="item">Item with modified properties, which should be save in db.</param>
        /// <returns>Return task.</returns>
        public async Task EditShoppingItem(ShoppingItemEntity item)
        {
            if (item is ShoppingItemPerPcs)
                await _genericStorage.InsertOrReplaceRow(item as ShoppingItemPerPcs);
            else
                await _genericStorage.InsertOrReplaceRow(item as ShoppingItemPerWeight);
        }

        /// <summary>
        /// Get all ShoppingItemEntries from database.
        /// </summary>
        /// <returns>List with database items.</returns>
        public async Task<List<ShoppingItemEntity>> GetShoppingList()
        {
            var listPerPcs = (await _genericStorage.GetRows<ShoppingItemPerPcs>()).ToList();
            var listPerWeight = (await _genericStorage.GetRows<ShoppingItemPerWeight>()).ToList();

            var list = new List<ShoppingItemEntity>(listPerPcs);
            list.AddRange(listPerWeight);

            return new List<ShoppingItemEntity>(list);
        }

        /// <summary>
        /// Used to insert few items to database.
        /// </summary>
        /// <returns>Return task.</returns>
        public async Task InitDatabase()
        {
            var shoppinglist = new List<ShoppingItemEntity>
            {
                new ShoppingItemPerPcs
                {
                    ImgPath = "koszulka.jpg",
                    Name = "Koszulka",
                    Price = 154.99,
                    ItemCount = 2
                },
                new ShoppingItemPerWeight
                {
                    ImgPath = "banany.jpg",
                    Name = "Banany",
                    Price = 7,
                    ItemAmount = 0.5
                },
                new ShoppingItemPerPcs
                {
                    ImgPath = "sukienka.jpg",
                    Name = "Sukienka",
                    Price = 250,
                    ItemCount = 1
                },
                new ShoppingItemPerWeight
                {
                    ImgPath = "arbuz.jpg",
                    Name = "Arbuz",
                    Price = 2.5,
                    ItemAmount = 1.5
                }
            };
            await _genericStorage.InsertRows(shoppinglist.OfType<ShoppingItemPerPcs>());
            await _genericStorage.InsertRows(shoppinglist.OfType<ShoppingItemPerWeight>());
        }
    }
}