﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI;

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
    }
}
