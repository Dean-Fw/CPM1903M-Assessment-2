using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_2
{
    class deck : card
    {
        private card[] Deck; //array of all cards
    
        public deck()
        {
            Deck = new card[52]; //constructs the deck and limits it size
        }
        public card[] retuurnDeck { get { return Deck; } } //gets the current deck

        public void fillDeck()
        {
            int index = 0;
            foreach(suit s in Enum.GetValues(typeof(suit))) //foreach suit value
            {
                foreach(value v in Enum.GetValues(typeof(value))) //and card value
                {
                    Deck[index] = new card { cardSuit = s, cardValue = v }; //add both values to array
                    index++;//increase the index
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

        public card deal()
        {
            return Deck[0];
        }
    }

}
