using Shopping.Core.POs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shopping.Core.Converters
{
    public class ShoppingCounterDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is ShoppingItemPerPcs)
            {
                return $"{(value as ShoppingItemPerPcs).ItemCount} szt.";
            }
            else if (value is ShoppingItemPerWeight)
            {
                return $"{(value as ShoppingItemPerWeight).ItemAmount} kg";
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
