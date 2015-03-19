using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlipNLearn.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public ObservableCollection<Deck> Decks { get; set; }
    }
}
