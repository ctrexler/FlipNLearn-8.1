using FlipNLearn.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace FlipNLearn.ValueConverters
{
    class ColorToApprovedColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            foreach (ApprovedColor ac in ViewModel.instance.ApprovedColors)
            {
                if (ac.Color == (Color)value)
                {
                    return ViewModel.instance.ApprovedColors.IndexOf(ac);
                }
            }
            return ViewModel.instance.ApprovedColors.IndexOf(ViewModel.instance.ApprovedColors.FirstOrDefault());
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
