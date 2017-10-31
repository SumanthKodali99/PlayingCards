using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PlayingCards
{
    public partial class Form1 : Form
    {
        Deck deck = new Deck();

        List<Hand> hands = new List<Hand>();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnDeal_Click(object sender, EventArgs e)
        {
            DealCards();

            DisplayCards();
        }

        private void DisplayCards()
        {
            txtResults.Text = "";

            for (int h = 0; h < 5; h++)
            {
                string handLine = "Player #" + (h+1) + ": ";

                //new list of cards, sorted ascending
                List<Card> sortedCards = new List<Card>();
                
                sortedCards = hands[h].Cards.OrderBy(x => x.Value ).ToList();

                for (int c = 0; c < 5; c++)
                {
                    if (c>0)
                    {
                        //append a hyphen
                        handLine += "-";
                    }
                    handLine += sortedCards[c].Caption;                    
                }
                txtResults.Text += handLine + "\r\n";
            }
        }

        private void DealCards()
        {
            Card topCard; //the current card from the deck

            //clear hands
            hands = new List<Hand>();

            //create new list of 5 hands
            for (int h = 0; h < 5; h++)
            {
                hands.Add(new Hand());
            }

            //shuffle deck
            deck.Shuffle();

            //deal 5 cards to 5 hands
            for (int h = 0; h < 5; h++)
            {
                for (int c = 0; c < 5; c++)
                {
                    topCard = deck.Cards[0]; //take the top (zeroth index) card

                    //give this card to the current hand
                    hands[h].Cards.Add(topCard);

                    //remove from the deck
                    deck.Cards.Remove(topCard);

                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Output.txt";
            File.WriteAllText(path, txtResults.Text);
        }
       
    }
}
