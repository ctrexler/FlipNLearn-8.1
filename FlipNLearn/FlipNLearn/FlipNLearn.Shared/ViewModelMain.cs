using FlipNLearn.DataModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using System.ComponentModel;

namespace FlipNLearn
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        
        public ObservableCollection<Set> Sets { get; set; }

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
        
        public Deck SelectedDeck { get; set; }

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

        public ViewModelMain()
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

        public void AddSet()
        {
            JsonFunc.AddSet(new Set { Name = NameBox, Color = Colors.Green }, Sets);
            SelectedSet = Sets.Last();
            SelectedSet.Decks = new ObservableCollection<Deck>();
        }

        public void AddDeck()
        {
            SelectedSet.Decks.Add(new Deck { Name = NameBox, Color = Colors.Green });
        }
    }
}
