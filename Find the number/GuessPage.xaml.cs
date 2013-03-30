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
    public partial class GuessPage : PhoneApplicationPage
    {
        public GuessPage()
        {
            InitializeComponent();
        }

        private void Number_box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Number_box.Text != "1" && Number_box.Text != "2" && Number_box.Text != "3" && Number_box.Text != "4" && Number_box.Text != "5" && Number_box.Text != "6" && Number_box.Text != "7" && Number_box.Text != "8" && Number_box.Text != "9" && Number_box.Text != "10")
            {
                MessageBox.Show("Tell me a number you dipshit!");
                Number_box.Text = "";
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Tries_bx.Text = App.lives.ToString();
            Number.Text = App.number.ToString();
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
            int comp = 0;

            switch (Comparison_bx.Text)
            {
                case "smaller than": comp = -1; break;
                case "larger than": comp = 1; break;
                case "equal to": comp = 0; break;
            }

            NavigationService.Navigate(new Uri(string.Format("/CheckPage.xaml?Comparator={0}&Number={1}", comp, Number_box.Text), UriKind.Relative));
        }



    }
}