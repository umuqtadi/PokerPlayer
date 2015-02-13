using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
    class PokerPlayer
    {
        // Enum of different hand types
        public enum HandType
        {
        }
        // Rank of hand that player holds
        public HandType HandRank
        {
            get;
        }
        // Constructor that isn't used
        public PokerPlayer() { }
        public bool HasPair()
        {
            return false;
        }
        public bool HasTwoPair()
        {
            return false;
        }
        public bool HasThreeOfAKind()
        {
            return false;
        }
        public bool HasStraight()
        {
            return false;
        }
        public bool HasFlush()
        {
            return false;
        }
        public bool HasFullHouse()
        {
            return false;
        }
        public bool HasFourOfAKind()
        {
            return false;
        }
        public bool HasStraightFlush()
        {
            return false;
        }
        public bool HasRoyalFlush()
        {
            return false;
        }
    }
    //Guides to pasting your Deck and Card class

    //  *****Deck Class Start*****



    //  *****Deck Class End*******

    //  *****Card Class Start*****



    //  *****Card Class End*******
}
