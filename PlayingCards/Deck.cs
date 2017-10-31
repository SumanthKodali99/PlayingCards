using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    public class Deck
    {
        //Public Properties
        public List<Card> Cards { get { return this.cardList; } }

        //Public Mthods
        public void Shuffle()
        {
            //reset the list of cards
            InitializeDeck();

            //create a new list, from which random cards will be inserted from the original list
            List<Card> shuffledList = new List<Card>();

            //generate random number

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            
            Card randomCard;

            for (int i = 0; i < 52; i++)
            {
                //get a card from a random position in the list
                randomCard = cardList[rnd.Next(0, cardList.Count)];

                //remove it from the original list
                cardList.Remove(randomCard);

                //add it to the new shuffled list
                shuffledList.Add(randomCard);
            }

            //replace the original list with the new shuffled list
            cardList = shuffledList;

        }


        //private variables
        private List<Card> cardList;

        //private Methods

        //constructor
        public Deck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            cardList = new List<Card>();

            foreach (SuitConstants suit in Enum.GetValues(typeof(SuitConstants)))
            {
                foreach (ValueConstants value in Enum.GetValues(typeof(ValueConstants)))
                {
                    cardList.Add(new Card() { Suit = suit, Value = value });
                }
            }
        }
        
    }
}
    