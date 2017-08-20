using Shopping.Core.Model.Entities.Interfaces;
using SQLite;

namespace Shopping.Core.Model.Entities
{
    /// <summary>
    /// Class for storing Shopping Item Entities
    /// </summary>
    public class ShoppingItemEntity : IEntity
    {
        public string Name { get; set; }

        public string ImgPath { get; set; }

        public double Price { get; set; }

        [PrimaryKey]
        [AutoIncrement]
        public int ShoppingId { get; set; }
    }

    /// <summary>
    /// Class for storing Shopping Item Entities per weight.
    /// </summary>
    public class ShoppingItemPerWeight : ShoppingItemEntity
    {
        public double ItemAmount { get; set; }
    }

    /// <summary>
    /// Class for storing Shopping Item Entities per pcs.
    /// </summary>
    public class ShoppingItemPerPcs : ShoppingItemEntity
    {
        public int ItemCount { get; set; }
    }
}