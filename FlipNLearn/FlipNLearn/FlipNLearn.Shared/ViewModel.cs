using FlipNLearn.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using System.ComponentModel;

namespace FlipNLearn
{
    public class ViewModel : INotifyPropertyChanged
    {
        public static readonly ViewModel instance = new ViewModel();

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        
        // Sets
        public ObservableCollection<Set> Sets { get; set; }

        // Selected Set
        public Set SelectedSetValue { get; set; }
        public Set SelectedSet
        {
            get { return this.SelectedSetValue; }
            set {
                if (value != this.SelectedSetValue)
                {
                    this.SelectedSetValue = value;
                    NotifyPropertyChanged("SelectedSet");
                }
            }
        }
        
        // Selected Deck
        public Deck SelectedDeck { get; set; }

        // NameBox (XAML)
        public string NameBoxValue { get; set; }
        public string NameBox
        {
            get { return this.NameBoxValue; }
            set {
                if (value != this.NameBoxValue)
                {
                    this.NameBoxValue = value;
                    NotifyPropertyChanged("NameBox");
                }
            }
        }

        // DataModel
        public ViewModel()
        {
            Sets = new ObservableCollection<Set>()
            {
                new Set() {
                    Name = "Geography",
                    Color = Colors.SteelBlue,
                    Decks = new ObservableCollection<Deck>() {
                        new Deck() {
                            Name = "US Capitals",
                            Cards = new List<Card>() {
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Alaska",
                                    BackText="Anchorage"
                                },
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Texas",
                                    BackText="Austin"
                                },
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Maine",
                                    BackText="Agusta"
                                },
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Vermont",
                                    BackText="Mont Pelier"
                                },
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Louisiana",
                                    BackText="Baton Rouge"
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
                            Cards = new List<Card>() {
                                new Card() {
                                    Color = Colors.DeepPink,
                                    FrontText="Sample Card 2.1.1F",
                                    BackText="Sample Card 2.1.2B"
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
        }

        public void AddSet()
        {
            JsonFunc.AddSet(new Set
            {
                Name = NameBox,
                Color = Colors.SteelBlue,
                Decks = new ObservableCollection<Deck>()
            });
            SelectedSet = Sets.Last();
        }

        public void AddDeck()
        {
            JsonFunc.AddDeck(new Deck { Name = NameBox });
        }
    }
}
