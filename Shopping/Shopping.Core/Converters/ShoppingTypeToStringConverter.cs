﻿using System;
using System.Globalization;
using Shopping.Core.Model.Entities;
using Xamarin.Forms;

namespace Shopping.Core.Converters
{
    /// <summary>
    /// Used to convert ShoppingItemEntry to string represented type.
    /// For ShoppingItemPerPcs is 'Na sztuki', for ShoppingItemPerWeight 'Na wagę'.
    /// </summary>
    public class ShoppingTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ShoppingItemPerPcs)
            {
                return "Na sztuki";
            }
            return "Na wagę";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}