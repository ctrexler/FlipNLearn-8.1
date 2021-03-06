﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace FlipNLearn.ValueConverters
{
    public class CheckCardListNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)parameter == "Stroke")
                return "White";
            else if ((string)parameter == "Dash") {
                if ((int)value < 1) {
                    return "5";
                }
                else {
                    return "2000";
                }
            }
            else if ((string)parameter == "Dash2")
            {
                if ((int)value < 2)
                {
                    return "5";
                }
                else
                {
                    return "2000";
                }
            }
            else if ((string)parameter == "Dash3")
            {
                if ((int)value < 3)
                {
                    return "5";
                }
                else
                {
                    return "2000";
                }
            }
            return "EXCEPTION!";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
