using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Find_the_number
{
    public partial class CheckPage : PhoneApplicationPage
    {
        public CheckPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string comp = this.NavigationContext.QueryString["Comparator"];
            string chNumber = this.NavigationContext.QueryString["Number"];

            switch (comp)
            {
                case "-1":
                    {
                        if (Int32.Parse(chNumber) < App.number)
                        {
                            Result_bx.Text = "YES!";
                            // add winning procedure
                        }
                        else
                        {
                            Result_bx.Text = "NO!";
                            App.lives -= 1;
                            // add lossing procedure
                        }
                    } break;
                case "1":
                    {
                        if (Int32.Parse(chNumber) > App.number)
                        {
                            Result_bx.Text = "YES!";
                            // add winning procedure
                        }
                        else
                        {
                            Result_bx.Text = "NO!";
                            App.lives -= 1;
                            // add lossing procedure
                        }
                    } break;
                case "0":
                    {
                        if (Int32.Parse(chNumber) == App.number)
                        {
                            Result_bx.Text = "YES!";
                            // add winning procedure
                        }
                        else
                        {
                            Result_bx.Text = "NO!";
                            App.lives -= 1;
                            // add lossing procedure
                        }
                    } break;

                default:
                    break;
            }


        }

        private void Retry_btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GuessPage.xaml", UriKind.Relative));
        }
    }
}