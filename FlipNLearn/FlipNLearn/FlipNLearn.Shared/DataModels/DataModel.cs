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
        public ObservableCollection<Set> Sets { get; set; }
        public Set SelectedSet { get; set; }
        public Deck SelectedDeck { get; set; }

        public DataModel()
        {
            Sets = new ObservableCollection<Set>()
            {
                new Set() {
                    Name = "Sample Set 1",
                    Color = Colors.Red,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck 1.1",
                            Color = Colors.Black,
                            Cards = new List<Card>() {
                                new Card() {
                                    FrontText="Sample Card 1.1.1F",
                                    BackText="Sample Card 1.1.2B"
                                }
                            }
                        },
                        new Deck() {
                            Name = "Sample Deck 1.2",
                            Color = Colors.Black,
                            Cards = new List<Card>() {
                                new Card() {
                                    FrontText="Sample Card 1.2.1F",
                                    BackText="Sample Card 1.2.2B"
                                }
                            }
                        }
                    }
                },
                new Set() {
                    Name = "Sample Set 2",
                    Color = Colors.Red,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck 2.1",
                            Color = Colors.Black,
                            Cards = new List<Card>() {
                                new Card() {
                                    FrontText="Sample Card 2.1.1F",
                                    BackText="Sample Card 2.1.2B"
                                }
                            }
                        },
                        new Deck() {
                            Name = "Sample Deck 2.2",
                            Color = Colors.Black,
                            Cards = new List<Card>() {
                                new Card() {
                                    FrontText="Sample Card 2.2.1F",
                                    BackText="Sample Card 2.2.2B"
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
