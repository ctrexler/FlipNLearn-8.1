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

            this.DataContext = ViewModel.instance;

            JsonFunc.Deserialize(ViewModel.instance);

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
            ViewModel.instance.SelectedDeck = (Deck)ListViewDecks.SelectedItem;
            Frame.Navigate(typeof(ViewDeck));
        }

        private void AddSetButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.instance.AddSet();
        }

        private void AddDeckButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.instance.AddDeck();
        }
    }
}
