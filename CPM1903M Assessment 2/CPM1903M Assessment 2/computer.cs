using CPM1903M_Assessment_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPM1903M_Assessment_2
{
    class computer : participant
    {
        //property to determine the playstyle of computer 
        public int playStyle { get; set; }

        //play style generated randomly
        public computer()
        {
            Random r = new Random();
            playStyle = r.Next(1, 3);
        }
        //method to allow the computer to choose a card to play 
        public override card chooseCard(hand Hand)
        {
            if(playStyle == 1)
            {
                return randomSelect(Hand);
            }
            else if(playStyle == 2)
            {
                return highestSelect(Hand);
            }
            return lowestSelect(Hand);

        }
        //method that allows for the random playstyle 
        private card randomSelect(hand Hand)
        {
            //cards are picked randomly from the hand 
            Random r = new Random();
            int indexOfCard = r.Next(0, Hand.Hand.Count - 1);
            card chosenCard = Hand.Hand[indexOfCard];
            Hand.Hand.RemoveAt(indexOfCard);
            return chosenCard;
        }
        //method that allows for the computer to play the highest cards 
        private card highestSelect(hand Hand)
        {
            //list created for a sorted hand
            List<card> Sortedhand = new List<card>();
            //sorted by card value
            Sortedhand = Hand.Hand.OrderBy(card => card.cardValue).ToList();
            //last value selected as it is the largest, then returned
            card selectedCard = Sortedhand[Sortedhand.Count - 1];
            return selectedCard;          
        }
        //method that allows for the computer to play the lowest cards
        private card lowestSelect(hand Hand)
        {
            //cards sorted and the smallest card is selected
            List<card> Sortedhand = new List<card>();
            Sortedhand = Hand.Hand.OrderBy(card => card.cardValue).ToList();
            card selectedCard = Sortedhand[0];
            return selectedCard;
        }

    }
}
