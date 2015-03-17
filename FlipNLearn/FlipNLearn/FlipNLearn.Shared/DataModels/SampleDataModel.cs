using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlipNLearn.DataModels
{
    public class SampleDataModel : DataModel
    {
        public SampleDataModel() : base()
        {
            Sets = new ObservableCollection<Set>()
            {
                new Set() {
                    Name = "Geography",
                    Color = Colors.Red,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck",
                            Color = Colors.Black,
                            Cards = new List<Card>() {
                                new Card() {
                                    FrontText="Test",
                                    BackText="Test"
                                }
                            }
                        }
                    }
                }
            };
            
            SelectedSet = Sets[0];
            SelectedDeck = Sets[0].Decks[0];
        }
    }
}
