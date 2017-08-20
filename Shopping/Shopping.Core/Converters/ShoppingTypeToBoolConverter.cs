using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace Shopping.Core.Converters
{
    /// <summary>
    /// Class used to convert string with type to bool.
    /// Possible types: Na wagę, Na sztuki
    /// </summary>
    public class ShoppingTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string) value == (string) parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
