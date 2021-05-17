using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CPM1903M_Assessment_3
{
    public class card: IEquatable<card>, IComparable<card>
    {
        public enum suit
        {
            Hearts,Spades,Diamonds,Clubs
        }

        public enum value
        {
            two = 2, three, four, five, six, seven,
            eight, nine, ten, jack, queen, king, ace
        }

        public suit cardSuit { get; set; }
        public value cardValue { get; set; }

        public bool Equals([AllowNull] card other)
        {
            if(cardValue == other.cardValue)
            {
                return true;
            }
            return false;
        }

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
