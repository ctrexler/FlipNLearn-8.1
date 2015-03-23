using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FlipNLearn.ValueConverters
{
    public class SelectedCardIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (ViewModel.instance.SelectedDeck.Cards.IndexOf(ViewModel.instance.SelectedCard) + 1).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
