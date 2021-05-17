using System;

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

            manager referee = new manager();
            
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
            
            gameLoop(playerHand, computerHand, referee);
            postGameProcess(Deck, playerHand, computerHand, referee);
            
            
        }
        static bool userResponse()
        {
            string response = Console.ReadLine().ToUpper();
            if(response != "Y" && response != "N")
            {
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
        static void gameLoop(hand playerHand, hand computerHand, manager referee)
        {
            while (playerHand.Hand.Count > 0)
            {
                Console.WriteLine("\nYou play the: ");
                card humanCard1 = playerHand.playCard();
                card humanCard2 = playerHand.playCard();
                Console.WriteLine($"For a toal score of: {Convert.ToInt32(humanCard1.cardValue) + Convert.ToInt32(humanCard2.cardValue)}");
                Console.WriteLine("\nThe Computer played the: ");
                card compCard1 = computerHand.playCard();
                card compCard2 = computerHand.playCard();
                Console.WriteLine($"For a toal score of: {Convert.ToInt32(compCard1.cardValue) + Convert.ToInt32(compCard2.cardValue)}");

                int result = referee.compareCards(humanCard1, humanCard2, compCard1, compCard2);
                referee.declareWinner(result);
                Console.WriteLine($"\nHuman {referee.Pscore} - {referee.Cscore} Computer");

                if (playerHand.Hand.Count > 1)
                {
                    Console.WriteLine("Would you like to continue this match?: (Y/N)");
                    bool toContinue = userResponse();
                    if (!toContinue)
                    {
                        Console.WriteLine($"The final scores are: Player {referee.Pscore} - {referee.Cscore} Computer ");
                        Console.WriteLine("\nThank You For Playing !");
                        break;
                    }
                }

            }
        }
        static void postGameProcess(deck Deck, hand playerHand, hand computerHand, manager referee)
        {
            if (playerHand.Hand.Count == 0)
            {
                if (referee.Pscore == referee.Cscore)
                {
                    for(int x = 0; x<=1; x++)
                    {
                        card dealtCard = Deck.deal();
                        playerHand.addToHand(dealtCard);
                        dealtCard = Deck.deal();
                        computerHand.addToHand(dealtCard);
                    }
                    gameLoop(playerHand, computerHand, referee);
                    
                    if(referee.Pscore == referee.Cscore)
                    {
                        postGameProcess(Deck,playerHand,computerHand,referee);
                    }
                }                
            }
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
        static void startUp()
        {
            deck Deck = new deck();
            Console.WriteLine("Generating deck ...");
            Deck.fillDeck();

            Console.WriteLine("Shuffling deck ...");
            Deck.shuffle();

            manager referee = new manager();

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

            gameLoop(playerHand, computerHand, referee);
            postGameProcess(Deck, playerHand, computerHand, referee);
        }
    }
}
