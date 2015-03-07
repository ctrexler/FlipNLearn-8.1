using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlipNLearn.DataModels
{
    public class Subset
    {
        public string Name { get; set; }
        public ObservableCollection<Deck> decks { get; set; }
    }
}
