using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Find_the_number.ScoreService;

namespace Find_the_number
{
    public partial class Leaderboard : PhoneApplicationPage
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ScoreServiceClient client = new ScoreServiceClient();
            client.GetLeaderboardCompleted += client_GetLeaderboardCompleted;
            client.GetLeaderboardAsync();
        }

        void client_GetLeaderboardCompleted(object sender, GetLeaderboardCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                leaderboard.ItemsSource = e.Result;
            }
        }
    }
}