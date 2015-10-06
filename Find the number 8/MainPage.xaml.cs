using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Find_the_number_8
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void play_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuessPage));
        }

        private void leaderboards_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Leaderboard));
        }
    }
}
