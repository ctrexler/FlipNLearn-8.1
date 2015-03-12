using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace FlipNLearn.DataModels
{
    public class Card
    {
        public int Id { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public byte[] FrontPic { get; set; }
        public byte[] BackPic { get; set; }
    }
}
