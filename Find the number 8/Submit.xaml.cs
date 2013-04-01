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
using Windows.UI.Popups;
using Find_the_number_8.ScoreService;

namespace Find_the_number_8
{
    public sealed partial class Submit : Page
    {
        public Submit()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            score.Text = App.score.ToString();
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            ScoreServiceClient client = new ScoreServiceClient();            
            bool success=await client.AddScoreAsync(name.Text, App.score);
            var messageDialog = new MessageDialog("Your score has been submitted");
            if (!success)
            {
               messageDialog.Content=  "An error occured while submitting your score. Please try again.";
            }            
            App.score = 0;            
            messageDialog.Commands.Add(new UICommand("OK", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            App.score = 0;
            Frame.Navigate(typeof(Leaderboard));
        }

    }
}
