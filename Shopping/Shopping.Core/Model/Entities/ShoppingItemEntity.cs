using Shopping.Core.Model.Entities.Interfaces;
using SQLite;

namespace Shopping.Core.Model.Entities
{
    public class ShoppingItemEntity : IEntity
    {
        public string Name { get; set; }

        public string ImgPath { get; set; }

        public double Price { get; set; }

        [PrimaryKey]
        [AutoIncrement]
        public int ShoppingId { get; set; }
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