using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_3
{
    public class manager 
    {
        //the manager keeps track of scores, compares cards and declares a winner. 
        public int Pscore { get; set; }
        public int Cscore { get; set; }
        //compares cards returninng a 0 for draw, 1 for player win, 2 for computer win
        public int compareCards(card Pcard1, card Pcard2, card Ccard1, card Ccard2)
        {
            int Pvalue = Convert.ToInt32(Pcard1.cardValue) + Convert.ToInt32(Pcard2.cardValue);
            int Cvalue = Convert.ToInt32(Ccard1.cardValue) + Convert.ToInt32(Ccard2.cardValue);
            if (Pvalue.Equals(Cvalue) == true)
            {
                return 0;  
            }
            else if(Pvalue.CompareTo(Cvalue) == 1)
            {
                return 1;
            }
            else if(Pvalue.CompareTo(Cvalue) != 1)
            {
                return 2;
            }
            return 3;

        }
        //declares winner of bout and increases their score
        public void declareWinner(int result)
        {
            if(result == 0)
            {
                Console.WriteLine("\nDRAW!");
            }
            else if(result == 1)
            {
                Pscore += 1;
                Console.WriteLine("\nPlayer Wins!");
            }
            else if(result ==2)
            {
                Cscore += 1;
                Console.WriteLine("\nThe Computer Wins!");
            }
            else
            {
                Console.WriteLine("\nBUG");
            }
        }
        
    }
}
