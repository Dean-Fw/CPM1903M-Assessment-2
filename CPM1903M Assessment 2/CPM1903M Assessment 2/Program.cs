using CPM1903M_Assessment_2;
using System;
using System.Collections.Generic;

namespace CPM1903M_Assessment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //deck created and shuffled 
            deck Deck = new deck();
            Console.WriteLine("Generating deck ...");
            Deck.fillDeck();

            Console.WriteLine("Shuffling deck ...");
            Deck.shuffle();
            //manager, player and oponent initialised
            manager referee = new manager();

            human player = new human();
            computer enemy = new computer();
            //hands created
            hand playerHand = new hand();
            hand computerHand = new hand();
            
            //cards being dealt
            Console.WriteLine("Dealing Cards ...");
            
            for (int x = 0; x<=9; x++)
            {
                card dealtCard = Deck.deal();
                playerHand.addToHand(dealtCard);

                dealtCard = Deck.deal();
                computerHand.addToHand(dealtCard);
            }
            //game loop begins
            gameLoop(Deck, playerHand, computerHand, referee, player, enemy);
            
            
        }
        //function created to recieve a yes or no from user
        static bool userResponse()
        {
            string response = Console.ReadLine().ToUpper();
            if(response != "Y" && response != "N")
            {
                //if response is not a y or n function will recurse until real response is taken
                Console.WriteLine("Please only respond with: \"Y\" or \"N\" ");
                bool consent = userResponse();
                return consent;
            }
            else if(response == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void gameLoop(deck Deck, hand playerHand, hand computerHand, manager referee, human player, computer enemy)
        {
            //loop will continue until broken or player runs out of cards
            while (playerHand.Hand.Count > 0)
            {                
                //played cards added to list
                List<card> humanCards = new List<card>() { player.chooseCard(playerHand), player.chooseCard(playerHand) };
                List<card> compCards = new List<card>() { enemy.chooseCard(computerHand), enemy.chooseCard(computerHand) };
                Console.Clear();
                //bout displayed
                Console.WriteLine("\nYou play the: ");
                displayPick(humanCards);
                Console.WriteLine($"For a toal score of: {Convert.ToInt32(humanCards[0].cardValue) + Convert.ToInt32(humanCards[1].cardValue)}");
                Console.WriteLine("\nThe Computer played the:");               
                displayPick(compCards);
                Console.WriteLine($"For a toal score of: {Convert.ToInt32(compCards[0].cardValue) + Convert.ToInt32(compCards[1].cardValue)}");
                //referee compares cards and declares winner
                int result = referee.compareCards(humanCards[0], humanCards[1], compCards[0], compCards[1]);
                referee.declareWinner(result);
                Console.WriteLine($"\nHuman {referee.Pscore} - {referee.Cscore} Computer");
                //if the player has more than two cards, they will be allowed to leave after any bout
                if (playerHand.Hand.Count > 2)
                {
                    //asked to continue
                    Console.WriteLine("Would you like to continue this match?: (Y/N)");
                    bool toContinue = userResponse();
                    if (!toContinue)
                    {
                        //if reply is "N" then final scores are played and the loop is broken 
                        Console.Clear();
                        Console.WriteLine($"The final scores are: Player {referee.Pscore} - {referee.Cscore} Computer ");
                        Console.WriteLine("\nThank You For Playing !");
                        break;
                    }
                    Console.Clear();
                }
                //if the player has two cards left the last match will begin
                if (playerHand.Hand.Count == 2)
                {
                    //last match begins and loop is broken
                    Console.WriteLine("\nLast Match! (press enter to continue)");
                    Console.ReadLine();
                    Console.Clear();
                    lastMatch(playerHand, computerHand, referee, Deck, player, enemy);
                    break;
                }
                if (playerHand.Hand.Count < 1)
                {
                    // with no cards left the postgame begins
                    postGameProcess(Deck, playerHand, computerHand, referee, player, enemy);
                }
            }                                    
            
        }
        //method to display all cards played 
        static void displayPick(List<card> Cards)
        {
            foreach (card x in Cards)
            {
                Console.WriteLine($"{x.cardValue} of {x.cardSuit}");
            }
        }
        //method to manage last match, where the players only have two cards and thus cant choose what to play
        private static void lastMatch(hand playerHand, hand computerHand, manager referee, deck Deck, human player, computer enemy)
        {
            //userr is prompted
            Console.WriteLine("\nYou finally play the: ");
            card humanCard1 = playerHand.playCard();
            card humanCard2 = playerHand.playCard();
            Console.WriteLine($"For a toal score of: {Convert.ToInt32(humanCard1.cardValue) + Convert.ToInt32(humanCard2.cardValue)}");
            Console.WriteLine("\nThe Computer played the: ");
            card compCard1 = computerHand.playCard();
            card compCard2 = computerHand.playCard();
            Console.WriteLine($"For a toal score of: {Convert.ToInt32(compCard1.cardValue) + Convert.ToInt32(compCard2.cardValue)}");
            //referee determines reult and post game begins
            int result = referee.compareCards(humanCard1, humanCard2, compCard1, compCard2);
            referee.declareWinner(result);
            Console.WriteLine($"\nHuman {referee.Pscore} - {referee.Cscore} Computer");
            postGameProcess(Deck, playerHand, computerHand, referee, player, enemy);           
        }
        //post game method
        static void postGameProcess(deck Deck, hand playerHand, hand computerHand, manager referee, human player, computer enemy)
        {
            //when the hand count is 0 a check is made to check if the match ended in a draw 
            if (playerHand.Hand.Count == 0)
            {
                if (referee.Pscore == referee.Cscore)
                {
                    //match played between human and computer
                    for(int x = 0; x<=1; x++)
                    {
                        card dealtCard = Deck.deal();
                        playerHand.addToHand(dealtCard);
                        dealtCard = Deck.deal();
                        computerHand.addToHand(dealtCard);
                    }
                    lastMatch(playerHand, computerHand, referee, Deck,player,enemy);
                    // if still a draw match is played again
                    if(referee.Pscore == referee.Cscore)
                    {
                        postGameProcess(Deck,playerHand,computerHand,referee, player, enemy);
                    }
                }                
            }
            //user is prompted the game is over and asked whether they want to continue
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Final Score: Player {referee.Pscore} - {referee.Cscore} Computer");
            Console.WriteLine("Would you like to play again? (Y/N)");
            bool response = userResponse();
            if (response)
            {
                Console.Clear();
                Console.WriteLine("\nGame Restarting...");
                startUp();
            }
            else if (!response)
            {
                Console.Clear();
                Console.WriteLine("\nThank you for playing!");
            }
        }
        //start up method to allow for the creation of new games
        static void startUp()
        {
            deck Deck = new deck();
            Console.WriteLine("Generating deck ...");
            Deck.fillDeck();

            Console.WriteLine("Shuffling deck ...");
            Deck.shuffle();

            manager referee = new manager();
            human player = new human();
            computer enemy = new computer();

            hand playerHand = new hand();
            hand computerHand = new hand();

            //cards being dealt
            Console.WriteLine("Dealing Cards ...");

            for (int x = 0; x <= 9; x++)
            {
                card dealtCard = Deck.deal();
                playerHand.addToHand(dealtCard);

                dealtCard = Deck.deal();
                computerHand.addToHand(dealtCard);
            }

            gameLoop(Deck, playerHand, computerHand, referee, player, enemy);
        }
    }
}
