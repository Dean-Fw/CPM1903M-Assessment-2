using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CPM1903M_Assessment_3
{
    public class card: IEquatable<card>, IComparable<card>
    {
        //enum that generates all the suits 
        public enum suit
        {
            Hearts,Spades,Diamonds,Clubs
        }
        //enum that generates all the card values 
        public enum value
        {
            two = 2, three, four, five, six, seven,
            eight, nine, ten, jack, queen, king, ace
        }
        //card properties created 
        public suit cardSuit { get; set; }
        public value cardValue { get; set; }
        //equals interface to check if cards are equal 
        public bool Equals([AllowNull] card other)
        {
            if(cardValue == other.cardValue)
            {
                return true;
            }
            return false;
        }
        //interface to compare cards 
        public int CompareTo([AllowNull] card other)
        {
            if(cardValue > other.cardValue)
            {
                return 1;
            }
            return 0;
        }
    }
}
