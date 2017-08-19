using Shopping.Core.Model.Entities;
using SQLite;
using Xamarin.Forms;

namespace Shopping.Core.POs
{
    public class ShoppingItemEntity :IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ShoppingId { get; set; }

        public string Name { get; set; }

        public string ImgPath { get; set; }

        public double Price { get; set; }
    }

    public class ShoppingItemPerWeight : ShoppingItemEntity
    {
        public double ItemAmount { get; set; }
    }

    public class ShoppingItemPerPcs : ShoppingItemEntity
    {
        public int ItemCount { get; set; }
    }
}
