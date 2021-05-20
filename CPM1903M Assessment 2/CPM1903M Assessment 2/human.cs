using CPM1903M_Assessment_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_2
{
    //class is child of the abstract class participant
    class human : participant
    {
        //function created to allow the selection of cards for the player
        public override card chooseCard(hand Hand)
        {
            //cards in hand shown
            Console.WriteLine("You have the following cards in your hand:\n ");
            ShowCards(Hand); 
            Console.WriteLine($"\nPick a card by entering its position in your hand: (1-{Hand.Hand.Count}), or by the value of the card (e.g \"three\")");
            //input taken
            string response = Console.ReadLine();
            try
            {
                //will try to convert to an int that represents the position of the card
                int position = Convert.ToInt32(response);
                card chosenCard = chosePositions(position, Hand);
                Hand.Hand.RemoveAt(position-1); //card removed from hand
                Console.Clear();
                Console.WriteLine($"\nYou have selected the {chosenCard.cardValue} of {chosenCard.cardSuit}\n");
                return chosenCard;
            }
            catch
            {
                //if the method cant convert to int it will assume you entered the card's value
                card chosenCard = chosePositions(response, Hand); 
                Console.Clear();
                Console.WriteLine($"\nYou have selected the {chosenCard.cardValue} of {chosenCard.cardSuit}");
                return chosenCard;
            }


        }
        //method created to show all the cards in the hand
        private void ShowCards(hand Hand)
        {
            int count = 0;
            foreach(card x in Hand.Hand)
            {
                count++;
                Console.WriteLine($"{count}. The {x.cardValue} of {x.cardSuit}");

            }
        }
        //method allows for polymorphism, if user enters and int this method will run to choose the card
        private card chosePositions(int response, hand Hand)
        {
            //to stop user inputting indexes over the limit or under
            if(response > Hand.Hand.Count || response < 0)
            {
                Console.Clear();
                Console.WriteLine($"Please Choose a target in range (1-{Hand.Hand.Count})");
                card ChosenCard = chooseCard(Hand);
                return ChosenCard;
            }
            //if within range card is taken 
            card chosenCard = Hand.Hand[response-1];
            return chosenCard;
        }
        //if user enters a string the method will change to allow for it
        private card chosePositions(string response, hand Hand)
        {
            //mehtod checks the value of every card in the hand against the input
            for(int x = 0; x< Hand.Hand.Count; x++)
            {
               //if response mathes card is returned
               if(response == Hand.Hand[x].cardValue.ToString())
               {
                    card ChosenCard = Hand.Hand[x];
                    Hand.Hand.RemoveAt(x);
                    return ChosenCard;

               }

            }
            //if no match is made then the method recurses back to make sure an input is taken
            Console.Clear();
            Console.WriteLine($"There is not a card with value {response}");
            card chosenCard = chooseCard(Hand);
            return chosenCard;
            
        }
    }
}
