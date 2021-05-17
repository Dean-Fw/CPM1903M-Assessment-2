using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_3
{
    class hand : deck
    {
        public List<card> Hand { get; set; } //hand created 

        public hand()
        {
            Hand = new List<card>(); //hand constructed 
        }
        //method to allow cards to be added to hand
        public void addToHand(card dealtCard)
        {
            Hand.Add(dealtCard); 
        }
        //method allowing for the playing of a card
        public card playCard()
        {
            //if hand is empty throw an invalid operation exception
            if(Hand.Count == 0)
            {
                throw new InvalidOperationException("Your hand is empty, you can not play anymore cards");
            }
            //first card in hand is played and message sent to user
            else
            {
                card playedCard = Hand[0];
                Hand.RemoveAt(0);
                Console.WriteLine($"The {playedCard.cardValue} of {playedCard.cardSuit}");
                return playedCard;
            }                          
        }
    }
}
