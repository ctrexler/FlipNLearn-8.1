using FlipNLearn.Common;
using FlipNLearn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace FlipNLearn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewDeck : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ViewDeck()
        {
            this.InitializeComponent();

            swipingSurface.ManipulationMode = ManipulationModes.TranslateX;
            swipingSurface.ManipulationStarted += swipingSurface_ManipulationStarted;
            swipingSurface.ManipulationCompleted += swipingSurface_ManipulationCompleted;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
            if (ViewModel.instance.IsCreatingDeck == true)
            {
                StackPanel_EditMode.Visibility = Visibility.Visible;

                AppBarButton_EditMode.Visibility = Visibility.Collapsed;
                AppBarButton_AddCard.Visibility = Visibility.Visible;
                AppBarButton_DeleteCard.Visibility = Visibility.Visible;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (ViewModel.instance.IsCreatingDeck == true)
            {
                e.Cancel = true;

                StackPanel_EditMode.Visibility = Visibility.Collapsed;

                AppBarButton_EditMode.Visibility = Visibility.Visible;
                AppBarButton_AddCard.Visibility = Visibility.Collapsed;
                AppBarButton_DeleteCard.Visibility = Visibility.Collapsed;

                ViewModel.instance.IsCreatingDeck = false;

                JsonFunc.Serialize();
            }
        }

        private void swipingSurface_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            // Nothing
        }

        int i = 0;
        async private void swipingSurface_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var velocities = e.Velocities;

            if (velocities.Linear.X < 0)
            {
                if (i + 1 > ViewModel.instance.SelectedDeck.Cards.Count -1)
                    i = 0;
                else
                    i++;
                if (!cardFacedFront)
                {
                    cardFront.Visibility = Visibility.Visible;
                    await FlipToFront.BeginAsync();
                    cardBack.Visibility = Visibility.Collapsed;
                    TextBox_FrontText.Visibility = Visibility.Visible;
                    TextBox_BackText.Visibility = Visibility.Collapsed;
                    cardFacedFront = true;
                }
                ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.ElementAt(i);
                TextBlock_CardNumber.Text = (i+1).ToString();
            }
            else if (velocities.Linear.X > 0)
            {
                if (i - 1 < 0)
                    i = ViewModel.instance.SelectedDeck.Cards.Count - 1;
                else
                    i--;
                if (!cardFacedFront)
                {
                    cardFront.Visibility = Visibility.Visible;
                    await FlipToFront.BeginAsync();
                    cardBack.Visibility = Visibility.Collapsed;
                    TextBox_FrontText.Visibility = Visibility.Visible;
                    TextBox_BackText.Visibility = Visibility.Collapsed;
                    cardFacedFront = true;
                }
                ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.ElementAt(i);
                TextBlock_CardNumber.Text = (i+1).ToString();
            }
        }

        bool cardFacedFront = true;
        private async void Card_Tapped(object sender, TappedRoutedEventArgs e)
        {

            if (cardFacedFront)
            {
                FlipToBack.BeginTime = new TimeSpan(0);
                cardBack.Visibility = Visibility.Visible;
                await FlipToBack.BeginAsync();
                cardFront.Visibility = Visibility.Collapsed;
                TextBox_FrontText.Visibility = Visibility.Collapsed;
                TextBox_BackText.Visibility = Visibility.Visible;
                cardFacedFront = false;
            }
            else
            {
                cardFront.Visibility = Visibility.Visible;
                await FlipToFront.BeginAsync();
                cardBack.Visibility = Visibility.Collapsed;
                TextBox_FrontText.Visibility = Visibility.Visible;
                TextBox_BackText.Visibility = Visibility.Collapsed;
                cardFacedFront = true;
            }
        }

        private void Button_EditDeck_Click(object sender, RoutedEventArgs e)
        {
                StackPanel_EditMode.Visibility = Visibility.Visible;

                AppBarButton_EditMode.Visibility = Visibility.Collapsed;
                AppBarButton_AddCard.Visibility = Visibility.Visible;
                AppBarButton_DeleteCard.Visibility = Visibility.Visible;

                ViewModel.instance.IsCreatingDeck = true;
        }

        Border LastSelected = new Border();
        private void Color_Tapped(object sender, TappedRoutedEventArgs e)
        {
            LastSelected.BorderThickness = new Thickness(1);
            (sender as Border).BorderThickness = new Thickness(3);
            LastSelected = (sender as Border);
            ViewModel.instance.AddCardColor = (GridViewColors.SelectedItem as ApprovedColor).Color;
            ViewModel.instance.SelectedCard.Color = (GridViewColors.SelectedItem as ApprovedColor).Color;
        }

        async private void Button_AddCard_Click(object sender, RoutedEventArgs e)
        {
            Color defaultColor = ViewModel.instance.SelectedCard.Color;
            ViewModel.instance.SelectedDeck.Cards.Add(new Card() { Color = defaultColor });
            ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.LastOrDefault();
            TextBlock_CardNumber.Text = ViewModel.instance.SelectedDeck.Cards.Count.ToString();
            i = ViewModel.instance.SelectedDeck.Cards.Count;
            StackPanel_CardArea.Visibility = Visibility.Visible;
            StackPanel_EditMode.Visibility = Visibility.Visible;

            if (!cardFacedFront)
            {
                cardFront.Visibility = Visibility.Visible;
                await FlipToFront.BeginAsync();
                cardBack.Visibility = Visibility.Collapsed;
                TextBox_FrontText.Visibility = Visibility.Visible;
                TextBox_BackText.Visibility = Visibility.Collapsed;
                cardFacedFront = true;
            }
        }

        private void Button_DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            //int cardIndex = (ViewModel.instance.SelectedDeck.Cards.IndexOf(ViewModel.instance.SelectedCard) - 1);
            JsonFunc.DeleteCard();

            if (ViewModel.instance.SelectedDeck.Cards.Count != 0)
            {
                ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.LastOrDefault();
                TextBlock_CardNumber.Text = (ViewModel.instance.SelectedDeck.Cards.IndexOf(ViewModel.instance.SelectedDeck.Cards.LastOrDefault()) + 1).ToString();
            }
            else
            {
                TextBlock_CardNumber.Text = "0";
                StackPanel_CardArea.Visibility = Visibility.Collapsed;
                StackPanel_EditMode.Visibility = Visibility.Collapsed;
            }

            //if (ViewModel.instance.SelectedDeck.Cards.Count > 2)
            //{
            //    ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.ElementAt(cardIndex);
            //    TextBlock_CardNumber.Text = cardIndex.ToString();
            //}
            //else if (ViewModel.instance.SelectedDeck.Cards.Count == 2)
            //{
            //    ViewModel.instance.SelectedCard = ViewModel.instance.SelectedDeck.Cards.ElementAt(cardIndex);
            //    TextBlock_CardNumber.Text = "1";
            //}
            //else
            //{
            //    TextBlock_CardNumber.Text = "0";
            //    Frame.Navigate(typeof(MainPage));
            //}
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            cardFront.Height = 125;
            cardFront.Width = 200;
            cardBack.Height = 125;
            cardBack.Width = 200;
            frontText.LineHeight = 22;
            backText.LineHeight = 22;
            frontText.FontSize = 18;
            backText.FontSize = 18;
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            cardFront.Height = 250;
            cardFront.Width = Window.Current.Bounds.Width;
            cardBack.Height = 250;
            cardBack.Width = Window.Current.Bounds.Width;
            frontText.LineHeight = 45;
            backText.LineHeight = 45;
            frontText.FontSize = 36;
            backText.FontSize = 36;
        }

    }
}
