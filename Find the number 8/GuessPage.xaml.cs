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
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Find_the_number_8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GuessPage : Page
    {
        public static int number;

        public GuessPage()
        {
            this.InitializeComponent();
            Random randGen = new Random();
            number = randGen.Next(1, 11);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Number_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Number_box.Text != "1" && Number_box.Text != "2" && Number_box.Text != "3" && Number_box.Text != "4" && Number_box.Text != "5" && Number_box.Text != "6" && Number_box.Text != "7" && Number_box.Text != "8" && Number_box.Text != "9" && Number_box.Text != "10")
            {
                var messageDialog = new MessageDialog("Tell me a number you dipshit!");
                await messageDialog.ShowAsync();
                Number_box.Text = "";
            }
        }

        private void Comparison_bx_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Comparison_bx.Text == "smaller than")
            {
                Comparison_bx.Text = "larger than";
            }
            else if (Comparison_bx.Text == "larger than")
            {
                Comparison_bx.Text = "equal to";
            }
            else if (Comparison_bx.Text == "equal to")
            {
                Comparison_bx.Text = "smaller than";
            }
        }

        private void Check_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Check_btn.Content.ToString() == "Go for more")
            {
                Random randGen = new Random();
                number = randGen.Next(1, 11);
                Card.Source = new BitmapImage(new Uri("ms-appx:Assets/card.png", UriKind.RelativeOrAbsolute));
                result.Text = "";
                Tries_bx.Text = "5";
                Check_btn.Content = "Check";

            }
            else if (Check_btn.Content.ToString() == "Try again")
            {
                Frame.Navigate(typeof(Submit));
            }
            else
            {
                switch (Comparison_bx.Text)
                {
                    case "smaller than":
                        {
                            if (Int32.Parse(Number_box.Text) > number)
                            {
                                Tries_bx.Text = (Int32.Parse(Tries_bx.Text) - 1).ToString();
                                if (Tries_bx.Text != "0")
                                {
                                    result.Text = "YES!";
                                }
                                else
                                {
                                    result.Text = "Get out of here. You've lost!";
                                    showCard();
                                    Check_btn.Content = "Try again";
                                }
                            }
                            else
                            {
                                Tries_bx.Text = (Int32.Parse(Tries_bx.Text) - 1).ToString();
                                if (Tries_bx.Text != "0")
                                {
                                    result.Text = "NO!";
                                }
                                else
                                {
                                    result.Text = "Get out of here. You've lost!";
                                    showCard();
                                    Check_btn.Content = "Try again";
                                }
                            }
                        } break;
                    case "larger than":
                        {
                            if (Int32.Parse(Number_box.Text) < number)
                            {
                                Tries_bx.Text = (Int32.Parse(Tries_bx.Text) - 1).ToString();
                                if (Tries_bx.Text != "0")
                                {
                                    result.Text = "YES!";
                                }
                                else
                                {
                                    result.Text = "Get out of here. You've lost!";
                                    showCard();
                                    Check_btn.Content = "Try again"; ;
                                }
                            }
                            else
                            {
                                Tries_bx.Text = (Int32.Parse(Tries_bx.Text) - 1).ToString();
                                if (Tries_bx.Text != "0")
                                {
                                    result.Text = "NO!";
                                }
                                else
                                {
                                    result.Text = "Get out of here. You've lost!";
                                    showCard();
                                    Check_btn.Content = "Try again";
                                }
                            }
                        } break;
                    case "equal to":
                        {
                            if (Number_box.Text == number.ToString())
                            {
                                result.Text = "YES! You win!";
                                showCard();
                                Check_btn.Content = "Go for more";
                                App.score++;
                                score.Text = App.score.ToString();
                            }
                            else
                            {
                                Tries_bx.Text = (Int32.Parse(Tries_bx.Text) - 1).ToString();
                                if (Tries_bx.Text != "0")
                                {
                                    result.Text = "NO!";
                                }
                                else
                                {
                                    result.Text = "Get out of here. You've lost!";
                                    showCard();
                                    Check_btn.Content = "Try again";
                                }
                            }
                        } break;
                }
            }
        }

        void showCard()
        {
            Card.Source = new BitmapImage(new Uri("ms-appx:Assets/" + number + ".png", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
