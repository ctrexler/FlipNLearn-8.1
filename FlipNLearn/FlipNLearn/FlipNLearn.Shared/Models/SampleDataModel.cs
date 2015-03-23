using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlipNLearn.Models
{
    public class SampleDataModel : ViewModel
    {
        public SampleDataModel() : base()
        {
            Sets = new ObservableCollection<Set>()
            {
                new Set() {
                    Name = "Sample Set 1",
                    Color = Colors.SteelBlue,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck 1.1",
                            Cards = new ObservableCollection<Card>() {
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Sample Card 1.1.1F",
                                    BackText="Sample Card 1.1.2B"
                                }
                            }
                        }
                    }
                },
                new Set() {
                    Name = "Sample Set 2",
                    Color = Colors.SteelBlue,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "Sample Deck 2.1",
                            Cards = new ObservableCollection<Card>() {
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Sample Card 2.1.1F",
                                    BackText="Sample Card 2.1.1B"
                                },
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Sample Card 2.1.2F",
                                    BackText="Sample Card 2.1.2B"
                                }
                            }
                        },
                        new Deck() {
                            Name = "Sample Deck 2.2"
                        }
                    }
                }
            };

            if (Sets.Count != 0)
            {
                SelectedSet = Sets[0];
                SelectedDeck = Sets[0].Decks[0];
            }

            // Approved Colors
            ApprovedColors = new List<ApprovedColor>()
            {
                new ApprovedColor() {
                    Color = Colors.Red,
                },
                new ApprovedColor() {
                    Color = Colors.Orange,
                },
                new ApprovedColor() {
                    Color = Colors.ForestGreen,
                },
                new ApprovedColor() {
                    Color = Colors.SteelBlue,
                },
                new ApprovedColor() {
                    Color = Colors.Purple,
                },
                new ApprovedColor() {
                    Color = Colors.DeepPink,
                },
                new ApprovedColor() {
                    Color = Colors.Black,
                }
            };
        }
    }
}
