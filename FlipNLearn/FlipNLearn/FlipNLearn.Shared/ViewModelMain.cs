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
    public class ViewModelMain : INotifyPropertyChanged
    {
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
        public ViewModelMain()
        {
            Sets = new ObservableCollection<Set>()
            {
                //new Set() {
                //    Name = "Sample Set 1",
                //    Color = Colors.SteelBlue,
                //    Decks = new ObservableCollection<Deck>() {
                //        new Deck() {
                //            Name = "Sample Deck 1.1",
                //            Cards = new List<Card>() {
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Sample Card 1.1.1F",
                //                    BackText="Sample Card 1.1.2B"
                //                }
                //            }
                //        }
                //    }
                //},
                //new Set() {
                //    Name = "Sample Set 2",
                //    Color = Colors.SteelBlue,
                //    Decks = new ObservableCollection<Deck>() {
                //        new Deck() {
                //            Name = "Sample Deck 2.1",
                //            Cards = new List<Card>() {
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Sample Card 2.1.1F",
                //                    BackText="Sample Card 2.1.2B"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Sample Card 2.1.2F",
                //                    BackText="Sample Card 2.1.2B"
                //                }
                //            }
                //        },
                //        new Deck() {
                //            Name = "Sample Deck 2.2"
                //        }
                //    }
                //}
            };

            if (Sets.Count != 0)
            {
                SelectedSet = Sets[0];
                SelectedDeck = Sets[0].Decks[0];
            }
        }

        public void AddSet(ViewModelMain vm)
        {
            JsonFunc.AddSet(vm, new Set
            {
                Name = NameBox,
                Color = Colors.SteelBlue,
                Decks = new ObservableCollection<Deck>()
            });
            SelectedSet = Sets.Last();
        }

        public void AddDeck(ViewModelMain vm)
        {
            JsonFunc.AddDeck(vm, new Deck { Name = NameBox });
        }
    }
}
