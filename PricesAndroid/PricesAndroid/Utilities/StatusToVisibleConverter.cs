using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using PricesAndroid.Models;
using Xamarin.Forms;

namespace PricesAndroid.Utilities
{
    public class StatusToVisibleConverter : IValueConverter
    {
        //public T CurrStatusObject { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Enum.TryParse<StatusEnum>((string)parameter, out var status)) return (StatusEnum)value == status;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
