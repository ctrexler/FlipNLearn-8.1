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
            Sets = new ObservableCollection<Set>()
            {
                new Set() {
                    Name = "Geography",
                    Color = Colors.Red,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck",
                            Color = Colors.Black,
                            Cards = new ObservableCollection<Card>() {
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

        public static void AddSet()
        {
            Sets.Add(new Set { Name = "Calculus" });
        }
    }
}
