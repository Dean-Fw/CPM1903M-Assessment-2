using System;

namespace CPM1903M_Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            deck deck = new deck();
            Console.WriteLine("Generating deck ...");
            deck.fillDeck();

            Console.WriteLine("Shuffling deck ...");
            deck.shuffle();

            Console.WriteLine("Dealing Card ...");
            card dealtCard = deck.deal();
            Console.WriteLine("The " + dealtCard.cardValue + " of " + dealtCard.cardSuit);

        }
    }
}
