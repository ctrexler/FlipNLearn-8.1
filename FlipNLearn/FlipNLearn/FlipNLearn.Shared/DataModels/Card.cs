using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipNLearn.DataModels
{
    public class Card
    {
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public BitmapImage FrontPic { get; set; }
        public BitmapImage BackPic { get; set; }
    }
}
