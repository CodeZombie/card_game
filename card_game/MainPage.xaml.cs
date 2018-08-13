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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//CARD GAME 2018 SUPER DELUXE EDITION 420 69
// MADE BY JEREMY C, STEFAN T, AND VANESSA L

namespace card_game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        public int active_card = 0;

        public Dictionary<string, BitmapImage> images = new Dictionary<string, BitmapImage>();

        public string[] card_values = new string[5];

        public Dictionary<int, Image> card = new Dictionary<int, Image>();

        public int shuffle_count = 0;

        public bool game_over = false;

        public void setCard(int card_, string value_)
        {
            card_values[card_] = value_; //store the value in a readable place
            card[card_].Source = images[value_]; //set the correct image
        }
        public MainPage()
        {
            this.InitializeComponent();

            card.Add(0, first_card);
            card.Add(1, second_card);
            card.Add(2, third_card);
            card.Add(3, fourth_card);
            card.Add(4, fifth_card);

            images.Add("2", new BitmapImage{UriSource = new Uri("ms-appx:///assets/2H.png")});
            images.Add("3", new BitmapImage { UriSource = new Uri("ms-appx:///assets/3H.png") });
            images.Add("4", new BitmapImage { UriSource = new Uri("ms-appx:///assets/4H.png") });
            images.Add("5", new BitmapImage { UriSource = new Uri("ms-appx:///assets/5H.png") });
            images.Add("6", new BitmapImage { UriSource = new Uri("ms-appx:///assets/6H.png") });
            images.Add("7", new BitmapImage { UriSource = new Uri("ms-appx:///assets/7H.png") });
            images.Add("8", new BitmapImage { UriSource = new Uri("ms-appx:///assets/8H.png") });
            images.Add("9", new BitmapImage { UriSource = new Uri("ms-appx:///assets/9H.png") });
            images.Add("A", new BitmapImage { UriSource = new Uri("ms-appx:///assets/AH.png") });
            images.Add("J", new BitmapImage { UriSource = new Uri("ms-appx:///assets/JH.png") });
            images.Add("K", new BitmapImage { UriSource = new Uri("ms-appx:///assets/KH.png") });
            images.Add("Q", new BitmapImage { UriSource = new Uri("ms-appx:///assets/QH.png") });
            images.Add("BACK", new BitmapImage { UriSource = new Uri("ms-appx:///assets/BACK.png") });

            for(var i = 0; i < 5; i++)
            {
                card[i].Source = images["BACK"];
            }
        }


        private void shuffle_cards()
        {
            
            if (shuffle_count < 2)
            {
                var names = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "A", "J", "K", "Q" };
                var r = new Random();
                for (var i = 0; i < 3; i++) //for the three top cards...
                {
                    int card_id = r.Next(names.Count); //pick a random card value

                    setCard(i, names[card_id]); //set that card to that value
                    names.Remove(names[card_id]); //remove that value from the list so it can't be chosen again.
                }
            }
            shuffle_count++;
        }

        private void new_game_button_Click(object sender, RoutedEventArgs e)
        {
            shuffle_count = 0;
            game_over = false;
            setCard(0, "BACK");
            setCard(1, "BACK");
            setCard(2, "BACK");
            setCard(3, "BACK");
            setCard(4 ,"BACK");
        }
        private void shuffle_button_Click(object sender, RoutedEventArgs e)
        {
            if (game_over == false)
            {
                shuffle_cards();
            }
        }

        private void choose_card(string value_)
        {

            var names = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "J", "K", "Q", "A"};

            var r = new Random();
            var ai_card = names[r.Next(names.Count)];

            setCard(4, ai_card);

            //send the chosen card to card 3
            setCard(3, value_);

            //compare the cards and pick a winner.
            if(names.IndexOf(value_) > names.IndexOf(ai_card))
            {
                //you win
                textBlock1.Text = "You won!";

            }
            else if(names.IndexOf(value_) == names.IndexOf(ai_card))
            {
                //tie
                textBlock1.Text = "You Tied !";
            }
            else
            {
                //you lose.
                textBlock1.Text = "You Lost :(!";
            }
            game_over = true;
        }

        private void first_button_click(object sender, RoutedEventArgs e)
        {
            if (game_over == false && shuffle_count != 0)
            {
                choose_card(card_values[0]);
            }
        }

        private void second_button_click(object sender, RoutedEventArgs e)
        {
            if (game_over == false && shuffle_count != 0)
            {
                choose_card(card_values[1]);
            }
        }

        private void third_button_click(object sender, RoutedEventArgs e)
        {
            if (game_over == false && shuffle_count != 0)
            {
                choose_card(card_values[2]);
            }
        }
    }


}
