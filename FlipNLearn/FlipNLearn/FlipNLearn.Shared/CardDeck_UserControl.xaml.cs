using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlipNLearn
{
    public sealed partial class CardDeck_UserControl : UserControl
    {
        public CardDeck_UserControl()
        {
            this.InitializeComponent();
        }

        bool cardFacedFront = true;
        async public void Card_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (cardFacedFront)
            {
                cardBack.Visibility = Visibility.Visible;
                await FlipToBack.BeginAsync();
                cardFront.Visibility = Visibility.Collapsed;
                cardFacedFront = false;
            }
            else
            {
                cardFront.Visibility = Visibility.Visible;
                await FlipToFront.BeginAsync();
                cardBack.Visibility = Visibility.Collapsed;
                cardFacedFront = true;
            }
        }
    }
}
