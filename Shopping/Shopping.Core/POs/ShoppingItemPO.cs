using Xamarin.Forms;

namespace Shopping.Core.POs
{
    public class ShoppingItemPO
    {
        public int ShoppingId { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
    }

    public class ShoppingItemPerWeight : ShoppingItemPO
    {
        public double ItemAmount { get; set; }
    }

    public class ShoppingItemPerPcs : ShoppingItemPO
    {
        public int ItemCount { get; set; }
        //public Color ItemColor { get; set; }
        //consider add color
    }
}
