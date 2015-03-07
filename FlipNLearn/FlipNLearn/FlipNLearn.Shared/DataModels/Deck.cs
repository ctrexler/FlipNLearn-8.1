using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;

namespace FlipNLearn.DataModels
{
    public class Deck
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Card> Cards { get; set; }
    }
}
