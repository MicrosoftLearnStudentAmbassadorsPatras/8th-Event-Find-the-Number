using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Find_the_number
{
    public partial class GuessPage : PhoneApplicationPage
    {
        public static int number;

        public GuessPage()
        {
            InitializeComponent();
            Random randGen = new Random();
            number = randGen.Next(1, 11);
        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            score.Text = App.score.ToString();
        }

        private void Number_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Number_box.Text != "1" && Number_box.Text != "2" && Number_box.Text != "3" && Number_box.Text != "4" && Number_box.Text != "5" && Number_box.Text != "6" && Number_box.Text != "7" && Number_box.Text != "8" && Number_box.Text != "9" && Number_box.Text != "10")
            {
                MessageBox.Show("Tell me a number you dipshit!");
                Number_box.Text = "";
            }
        }

        private void Comparison_bx_Tap(object sender, System.Windows.Input.GestureEventArgs e)
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
                Card.Source = new BitmapImage(new Uri("/Images/card.png", UriKind.RelativeOrAbsolute));
                result.Text = "";
                Tries_bx.Text = "5";
                Check_btn.Content = "Check";

            }
            else if (Check_btn.Content.ToString() == "Try again")
            {
                NavigationService.Navigate(new Uri("/Submit.xaml", UriKind.Relative));
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
            Card.Source = new BitmapImage(new Uri("/Images/" + number + ".png", UriKind.RelativeOrAbsolute));
        }



    }
}