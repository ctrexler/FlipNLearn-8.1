using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipNLearn.Data_Models
{
    class Card
    {
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public BitmapImage MyProperty { get; set; }
    }
}
