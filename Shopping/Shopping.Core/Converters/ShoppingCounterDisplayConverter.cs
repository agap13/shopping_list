using System;
using System.Globalization;
using Shopping.Core.Model.Entities;
using Xamarin.Forms;

namespace Shopping.Core.Converters
{
    /// <summary>
    /// Class used to display ItemCount or ItemAmount with units.
    /// </summary>
    public class ShoppingCounterDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pcs = value as ShoppingItemPerPcs;
            if (pcs != null)
            {
                return $"{pcs.ItemCount} szt.";
            }
            var weight = value as ShoppingItemPerWeight;
            if (weight != null)
            {
                return $"{weight.ItemAmount} kg";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}