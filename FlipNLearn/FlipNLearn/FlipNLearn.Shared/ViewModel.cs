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
        public void NotifyPropertyChanged(String info)
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

        // Deck Currently Being Viewed
        public ObservableCollection<Card> _currentDeck { get; set; }
        public ObservableCollection<Card> currentDeck
        {
            get
            {
                if (_currentDeck == null)
                {
                    _currentDeck = SelectedDeck.Cards;
                }
                return _currentDeck;
            }
            set
            {
                if (value != this._currentDeck)
                {
                    this._currentDeck = value;
                    NotifyPropertyChanged("currentDeck");
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

        // Create Deck Edit Mode Bool
        public bool IsCreatingDeck { get; set; }

        // ViewModel Constructor
        public ViewModel()
        {
            // Hard-coded Data
            IsCreatingDeck = false;
            Sets = new ObservableCollection<Set>();
            currentDeck = new ObservableCollection<Card>();

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
                    Color = Colors.OrangeRed,
                },
                new ApprovedColor() {
                    Color = Colors.DarkOrange,
                },
                new ApprovedColor() {
                    Color = Colors.ForestGreen,
                },
                new ApprovedColor() {
                    Color = Colors.SteelBlue,
                },
                new ApprovedColor() {
                    Color = Colors.DarkViolet,
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
