using CPM1903M_Assessment_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_2
{
    class human : participant
    {

        public override card chooseCard(hand Hand)
        {
            Console.WriteLine("You have the following cards in your hand:\n ");
            ShowCards(Hand);
            Console.WriteLine($"\nPick a card by entering its position in your hand: (1-{Hand.Hand.Count}), or by the value of the card (e.g \"three\"");
            string response = Console.ReadLine();
            try
            {
                int position = Convert.ToInt32(response);
                card chosenCard = chosePositions(position, Hand);
                Hand.Hand.RemoveAt(position-1);
                Console.Clear();
                Console.WriteLine($"\nYou have selected the {chosenCard.cardValue} of {chosenCard.cardSuit}\n");
                return chosenCard;
            }
            catch
            {
                card chosenCard = chosePositions(response, Hand);
                Console.Clear();
                Console.WriteLine($"\nYou have selected the {chosenCard.cardValue} of {chosenCard.cardSuit}");
                return chosenCard;
            }


        }

        public void ShowCards(hand Hand)
        {
            int count = 0;
            foreach(card x in Hand.Hand)
            {
                count++;
                Console.WriteLine($"{count}. The {x.cardValue} of {x.cardSuit}");

            }
        }
        public card chosePositions(int response, hand Hand)
        {
            if(response > Hand.Hand.Count || response < 0)
            {
                Console.Clear();
                Console.WriteLine($"Please Choose a target in range (1-{Hand.Hand.Count})");
                card ChosenCard = chooseCard(Hand);
                return ChosenCard;
            }
            card chosenCard = Hand.Hand[response-1];
            return chosenCard;
        }
        public card chosePositions(string response, hand Hand)
        {
            for(int x = 0; x< Hand.Hand.Count; x++)
            {
               if(response == Hand.Hand[x].cardValue.ToString())
               {
                    card ChosenCard = Hand.Hand[x];
                    Hand.Hand.RemoveAt(x);
                    return ChosenCard;

               }

            }
            Console.WriteLine($"There is not a card with value {response}");
            card chosenCard = chooseCard(Hand);
            return chosenCard;
            
        }
    }
}
