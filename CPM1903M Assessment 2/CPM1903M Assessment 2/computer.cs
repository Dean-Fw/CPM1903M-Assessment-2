using CPM1903M_Assessment_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPM1903M_Assessment_2
{
    class computer : participant
    {
        public int playStyle { get; set; }

        public computer()
        {
            Random r = new Random();
            playStyle = r.Next(1, 3);
        }
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
        public card randomSelect(hand Hand)
        {
            Random r = new Random();
            int indexOfCard = r.Next(0, Hand.Hand.Count - 1);
            card chosenCard = Hand.Hand[indexOfCard];
            Hand.Hand.RemoveAt(indexOfCard);
            return chosenCard;
        }
        public card highestSelect(hand Hand)
        {
            List<card> Sortedhand = new List<card>();
            Sortedhand = Hand.Hand.OrderBy(card => card.cardValue).ToList();
            card selectedCard = Sortedhand[Sortedhand.Count - 1];
            return selectedCard;          
        }
        public card lowestSelect(hand Hand)
        {
            List<card> Sortedhand = new List<card>();
            Sortedhand = Hand.Hand.OrderBy(card => card.cardValue).ToList();
            card selectedCard = Sortedhand[0];
            return selectedCard;
        }

    }
}
