using System;
using System.Collections.Generic;
using System.Text;

namespace FlipNLearn.DataModels
{
    public class Subset
    {
        public string Name { get; set; }
        public List<Deck> decks { get; set; }
    }
}
