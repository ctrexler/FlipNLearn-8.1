using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;

namespace FlipNLearn.DataModels
{
    public class Deck
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public ObservableCollection<Card> Cards { get; set; }
    }
}
