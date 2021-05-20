using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_3
{
    public class deck : card
    {
        private List<card> Deck; //list of all cards
    
        public deck()
        {
            Deck = new List<card>(); //constructs the deck
        }
        public List<card> retuurnDeck { get { return Deck; } } //gets the current deck

        public void fillDeck()
        {
            foreach(suit s in Enum.GetValues(typeof(suit))) //foreach suit value
            {
                foreach(value v in Enum.GetValues(typeof(value))) //and card value
                {
                    Deck.Add(new card { cardSuit = s, cardValue = v }); //add both values to deck
                }
            }
        }

        public void shuffle()
        {
            Random r = new Random();
            card temp;

            //shuffle cards 1000 times
            for(int shuffCount = 0; shuffCount < 1000; shuffCount++)
            {
                for( int index = 0; index < 52; index++)
                {
                    int nextcardIndex = r.Next(13);
                    temp = Deck[index];
                    Deck[index] = Deck[nextcardIndex];
                    Deck[nextcardIndex] = temp;
                }
            }

        }
        //deal method 
        public card deal()
        {
            //cards dealed from the top of the deck then returned
            card dealtCard = Deck[0];
            Deck.RemoveAt(0);
            return dealtCard;            
        }
    }

}
