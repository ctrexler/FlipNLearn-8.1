using FlipNLearn.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;
using System.ComponentModel;
using Windows.UI.Core;

namespace FlipNLearn
{
    public class ViewModel : INotifyPropertyChanged
    {
        public static ViewModel instance;

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
        public ObservableCollection<Set> _Sets { get; set; }
        public ObservableCollection<Set> Sets
        {
            get { return this._Sets; }
            set {
                if (value != this._Sets)
                {
                    this._Sets = value;
                    NotifyPropertyChanged("Sets");
                    NotifyPropertyChanged("SelectedSet");
                    NotifyPropertyChanged("SelectedDeck");
                }
            }
        }

        // Selected Set
        private Set _SelectedSet = null;
        public Set SelectedSet
        {
            get
            {
                if (_SelectedSet == null)
                {
                    _SelectedSet = Sets.FirstOrDefault();
                }
                return _SelectedSet;
            }
            set {
                if (value != this._SelectedSet)
                {
                    this._SelectedSet = value;
                    NotifyPropertyChanged("SelectedSet");
                }
            }
        }

        // Selected Deck
        private Deck _SelectedDeck = null;
        public Deck SelectedDeck
        {
            get
            {
                if (_SelectedDeck == null)
                {
                    if (SelectedSet == null)
                    {
                        return null;
                    }
                    _SelectedDeck = SelectedSet.Decks.FirstOrDefault();
                }
                return _SelectedDeck;
            }
            set
            {
                if (value != this._SelectedDeck)
                {
                    this._SelectedDeck = value;
                    NotifyPropertyChanged("SelectedDeck");
                }
            }
        }

        // Selected Card
        private Card _SelectedCard;
        public Card SelectedCard
        {
            get
            {
                return _SelectedCard;
            }
            set
            {
                _SelectedCard = value;
                NotifyPropertyChanged("SelectedCard");
            }
        }

        // Adding Set
        public string _AddSetName { get; set; }
        public string AddSetName
        {
            get { return this._AddSetName; }
            set {
                if (value != this._AddSetName)
                {
                    this._AddSetName = value;
                    NotifyPropertyChanged("AddSetName");
                }
            }
        }
        public Color AddSetColor { get; set; }
        
        // Adding Deck
        public string _AddDeckName { get; set; }
        public string AddDeckName
        {
            get { return this._AddDeckName; }
            set
            {
                if (value != this._AddDeckName)
                {
                    this._AddDeckName = value;
                    NotifyPropertyChanged("AddDeckName");
                }
            }
        }
        
        // Adding Card
        public string _AddCardFrontText { get; set; }
        public string AddCardFrontText
        {
            get { return this._AddCardFrontText; }
            set
            {
                if (value != this._AddCardFrontText)
                {
                    this._AddCardFrontText = value;
                    NotifyPropertyChanged("AddCardFrontText");
                }
            }
        }
        public string _AddCardBackText { get; set; }
        public string AddCardBackText
        {
            get { return this._AddCardBackText; }
            set
            {
                if (value != this._AddCardBackText)
                {
                    this._AddCardBackText = value;
                    NotifyPropertyChanged("AddCardBackText");
                }
            }
        }
        public Color AddCardColor { get; set; }

        // Approved Colors
        public List<ApprovedColor> ApprovedColors { get; set; }

        // ViewModel Constructor
        public ViewModel()
        {
            // Hard-coded Data
            Sets = new ObservableCollection<Set>();
            //{
                //new Set() {
                //    Name = "Geography",
                //    Color = Colors.SteelBlue,
                //    Decks = new ObservableCollection<Deck>() {
                //        new Deck() {
                //            Name = "US Capitals",
                //            Cards = new ObservableCollection<Card>() {
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Alaska",
                //                    BackText="Anchorage"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Texas",
                //                    BackText="Austin"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Maine",
                //                    BackText="Augusta"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Vermont",
                //                    BackText="Mont Pelier"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Louisiana",
                //                    BackText="Baton Rouge"
                //                }
                //            }
                //        },
                //        new Deck() {
                //            Name = "Elements",
                //            Cards = new ObservableCollection<Card>() {
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Es",
                //                    BackText="Einsteinium"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Ag",
                //                    BackText="Silver"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Hg",
                //                    BackText="Mercury"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Y",
                //                    BackText="Yttrium"
                //                },
                //                new Card() {
                //                    Color = Colors.DeepPink,
                //                    FrontText="Rw",
                //                    BackText="Doesn't Exist!"
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
                //            Cards = new ObservableCollection<Card>() {
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
            //};

            ViewModel.instance = this;

            InitializeColorGrid();
        }

        public void AddSet()
        {
            JsonFunc.AddSet(new Set
            {
                Name = AddSetName,
                Color = AddSetColor,
                Decks = new ObservableCollection<Deck>()
            });
            SelectedSet = Sets.Last();
        }

        public void AddDeck()
        {
            JsonFunc.AddDeck(new Deck {
                Name = AddDeckName,
            });
        }

        public void AddCard()
        {
            JsonFunc.AddCard(new Card
            {
                FrontText = AddCardFrontText,
                BackText = AddCardBackText,
                Color = AddCardColor
            });
        }

        public void InitializeColorGrid() {
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
