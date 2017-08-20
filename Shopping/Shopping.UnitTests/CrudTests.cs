using System.Linq;
using Shopping.Core.Model.Entities;
using Shopping.Core.Services;
using Shopping.Core.Services.Stubs;
using Xunit;

namespace Shopping.UnitTests
{
    public class CrudTests
    {
        private IShoppingService _shoppingService;

        public CrudTests()
        {
            _shoppingService = new ShoppingServiceStub();
        }

        [Fact]
        public async void AddShoppingItemPerPcsTest()
        {
            int beforeCounter = (await _shoppingService.GetShoppingList()).Count;
            var item = new ShoppingItemPerPcs
            {
                ShoppingId = 1,
                ImgPath = "koszulka.jpg",
                Name = "Koszulka",
                Price = 154.99,
                ItemCount = 2
            };
            await _shoppingService.AddShoppingItem(item);

            var shoppingList = await _shoppingService.GetShoppingList();
            int afterCounter = shoppingList.Count;

            Assert.Equal(beforeCounter + 1, afterCounter);

            Assert.NotEmpty(shoppingList);
        }

        [Fact]
        public async void AddShoppingItemPerWeightTest()
        {
            int beforeCounter = (await _shoppingService.GetShoppingList()).Count;
            var item = new ShoppingItemPerWeight
            {
                ShoppingId = 2,
                ImgPath = "banany.jpg",
                Name = "Banany",
                Price = 7,
                ItemAmount = 0.5
            };
            await _shoppingService.AddShoppingItem(item);

            var shoppingList = await _shoppingService.GetShoppingList();
            int afterCounter = shoppingList.Count;

            Assert.Equal(beforeCounter + 1, afterCounter);

            Assert.NotEmpty(shoppingList);
        }

        [Fact]
        public async void DeleteShoppingItem()
        {
            int beforeCounter = (await _shoppingService.GetShoppingList()).Count;
            var item = new ShoppingItemPerWeight
            {
                ShoppingId = 2,
                ImgPath = "banany.jpg",
                Name = "Banany",
                Price = 7,
                ItemAmount = 0.5
            };
            await _shoppingService.AddShoppingItem(item);
            int afterCounter = (await _shoppingService.GetShoppingList()).Count;

            Assert.Equal(beforeCounter + 1, afterCounter);

            await _shoppingService.DeleteShoppingItem(item);

            afterCounter = (await _shoppingService.GetShoppingList()).Count;

            Assert.Equal(beforeCounter, afterCounter);
        }

        [Fact]
        public async void UpdateShoppingItem()
        {
            var item = new ShoppingItemPerWeight
            {
                ShoppingId = 2,
                ImgPath = "banany.jpg",
                Name = "Banany",
                Price = 7,
                ItemAmount = 0.5
            };

            await _shoppingService.AddShoppingItem(item);

            item.Name = "Banany2";

            await _shoppingService.EditShoppingItem(item);

            var itemAfterUpdate = (await _shoppingService.GetShoppingList())
                .FirstOrDefault(x => x.ShoppingId == item.ShoppingId);

            Assert.NotNull(itemAfterUpdate);
            Assert.Equal(itemAfterUpdate?.Name, "Banany2");
            Assert.NotEqual(itemAfterUpdate?.Name, "Banany");
        }

        [Fact]
        public async void ClearShoppingItems()
        {
            var item = new ShoppingItemPerWeight
            {
                ShoppingId = 2,
                ImgPath = "banany.jpg",
                Name = "Banany",
                Price = 7,
                ItemAmount = 0.5
            };

            await _shoppingService.AddShoppingItem(item);

            var shoppingList = await _shoppingService.GetShoppingList();

            Assert.NotEmpty(shoppingList);

            await _shoppingService.ClearShoppingList();

            shoppingList = await _shoppingService.GetShoppingList();

            Assert.Empty(shoppingList);
        }

        [Fact]
        public async void GetShoppingItems()
        {
            await _shoppingService.ClearShoppingList();

            var shoppingList = await _shoppingService.GetShoppingList();

            Assert.Empty(shoppingList);

            var item = new ShoppingItemPerWeight
            {
                ShoppingId = 2,
                ImgPath = "banany.jpg",
                Name = "Banany",
                Price = 7,
                ItemAmount = 0.5
            };

            await _shoppingService.AddShoppingItem(item);

            var counter = (await _shoppingService.GetShoppingList()).Count;
            Assert.Equal(counter, 1);
            var item2 = new ShoppingItemPerPcs
            {
                ShoppingId = 1,
                ImgPath = "koszulka.jpg",
                Name = "Koszulka",
                Price = 154.99,
                ItemCount = 2
            };

            await _shoppingService.AddShoppingItem(item2);

            counter = (await _shoppingService.GetShoppingList()).Count;

            Assert.Equal(counter, 2);
        }
    }
}
