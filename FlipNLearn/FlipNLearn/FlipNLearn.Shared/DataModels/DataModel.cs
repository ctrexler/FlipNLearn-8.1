using FlipNLearn.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlipNLearn.DataModels
{
    public class DataModel
    {
        public List<Set> Sets { get; set; }
        public Set SelectedSet { get; set; }
        public Deck SelectedDeck { get; set; }

        public DataModel()
        {

        }
    }
}
