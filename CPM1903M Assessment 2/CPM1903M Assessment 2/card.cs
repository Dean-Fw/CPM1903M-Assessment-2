using System;
using System.Collections.Generic;
using System.Text;

namespace CPM1903M_Assessment_2
{
    class card
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
    }
}
