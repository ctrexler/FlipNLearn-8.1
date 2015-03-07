using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FlipNLearn.ValueConverters
{
    public sealed class ListToCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((List<object>)value).Count.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
