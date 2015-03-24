using FlipNLearn.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlipNLearn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }


        private void Set_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.instance.SelectedSet = (Set)ListViewSets.SelectedItem;
        }

        private void Deck_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ((ListViewDecks.SelectedItem as Deck).Cards != null
                && (ListViewDecks.SelectedItem as Deck).Cards.Count != 0)
            {
                ViewModel.instance.SelectedDeck = (Deck)ListViewDecks.SelectedItem;
                ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards[0];
                Frame.Navigate(typeof(ViewDeck));
            }
        }

        private void Button_CreateDeck_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_DeckName.Text != "")
            {
                ViewModel.instance.SelectedSet.Decks.Add(
                    new Deck()
                    {
                        Name = TextBox_DeckName.Text,
                        Cards = new ObservableCollection<Card>()
                    }
                );
                ViewModel.instance.SelectedDeck = ViewModel.instance.SelectedSet.Decks.Last();
                Frame.Navigate(typeof(CreateDeck));
            }
        }

        private void Button_SaveSet_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_SetName.Text != ""
                && GridViewColors.SelectedItem != null)
            {
                ViewModel.instance.AddSet();
                Flyout_AddSet.Hide();

                TextBox_SetName.Text = "";
            }
        }

        private void Button_CancelSet_Click(object sender, RoutedEventArgs e)
        {
            Flyout_AddSet.Hide();
            
            TextBox_SetName.Text = "";
        }
        
        Border LastSelected = new Border();
        private void Color_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LastSelected.BorderThickness = new Thickness(0);
            (sender as Border).BorderThickness = new Thickness(3);
            LastSelected = (sender as Border);
            ViewModel.instance.AddSetColor = (GridViewColors.SelectedItem as ApprovedColor).Color;

            foreach (Set set in ViewModel.instance.Sets)
            {
                System.Diagnostics.Debug.WriteLine(set.Name);
            }
        }

        private void Button_CancelDeck_Click(object sender, RoutedEventArgs e)
        {
            Flyout_CreateDeck.Hide();
            TextBox_DeckName.Text = "";
        }

        private void Context_EditDeck_Click(object sender, RoutedEventArgs e)
        {
            var menuFlyoutItem = sender as MenuFlyoutItem;
            ViewModel.instance.SelectedDeck = menuFlyoutItem.DataContext as Deck;
            Frame.Navigate(typeof(CreateDeck));
        }

        private void Context_DeleteSet_Click(object sender, RoutedEventArgs e)
        {
            var menuFlyoutItem = sender as MenuFlyoutItem;
            ViewModel.instance.SelectedSet = menuFlyoutItem.DataContext as Set;
            JsonFunc.DeleteSet();

            if (ViewModel.instance.Sets.Count != 0)
            {
                ViewModel.instance.SelectedSet = ViewModel.instance.Sets.First();
            }
        }

        private void Context_DeleteDeck_Click(object sender, RoutedEventArgs e)
        {
            var menuFlyoutItem = sender as MenuFlyoutItem;
            ViewModel.instance.SelectedDeck = menuFlyoutItem.DataContext as Deck;
            JsonFunc.DeleteDeck();

            if (ViewModel.instance.SelectedSet.Decks.Count != 0)
            {
                ViewModel.instance.SelectedDeck = ViewModel.instance.SelectedSet.Decks.First();
            }
        }
    }
}
