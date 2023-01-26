using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using PricesAndroid.Models;
using Xamarin.Forms;

namespace PricesAndroid.Utilities
{
    public class StatusToVisibleConverter<T> : IValueConverter
    {
        public T CurrStatusObject { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (CurrStatusObject.ToString() == "Created") return (StatusEnum)value == StatusEnum.Created;
            if (CurrStatusObject.ToString() == "InProgress") return (StatusEnum)value == StatusEnum.InProgress;
            if (CurrStatusObject.ToString() == "Done") return (StatusEnum)value == StatusEnum.Done;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (CurrStatusObject.ToString() == "Created") return (StatusEnum)value == StatusEnum.Created;
            if (CurrStatusObject.ToString() == "InProgress") return (StatusEnum)value == StatusEnum.InProgress;
            if (CurrStatusObject.ToString() == "Done") return (StatusEnum)value == StatusEnum.Done;

            return false;
        }
    }
}
