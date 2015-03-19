using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlipNLearn.DataModels
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
