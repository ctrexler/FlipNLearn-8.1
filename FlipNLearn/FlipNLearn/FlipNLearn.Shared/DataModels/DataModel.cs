using FlipNLearn.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;

namespace FlipNLearn.DataModels
{
    public class DataModel
    {
        public static ObservableCollection<Set> Sets { get; set; }
        public static Set SelectedSet { get; set; }
        public static Deck SelectedDeck { get; set; }

        public DataModel()
        {
            Sets = new ObservableCollection<Set>();
        }
    }
}
