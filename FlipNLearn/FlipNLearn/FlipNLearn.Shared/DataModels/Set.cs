using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;

namespace FlipNLearn.DataModels
{
    public class Set
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Subset> Subsets { get; set; }
        public List<Deck> Decks { get; set; }
    }
}
