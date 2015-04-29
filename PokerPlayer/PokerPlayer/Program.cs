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
        public List<Card> playerHand = new List<Card>();

        public void DrawHand(List<Card> cards)
        {
            playerHand = cards;
        }
        // Enum of different hand types
        public enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }
        // Rank of hand that player holds
        public HandType HandRank
        {
            get
            {
                if (this.HasRoyalFlush())
                {
                    return HandType.RoyalFlush;
                }
                else if (this.HasStraightFlush())
                {
                    return HandType.StraightFlush;
                }
                else if (this.HasFourOfAKind())
                {
                    return HandType.FourOfAKind;
                }
                else if (this.HasFullHouse())
                {
                    return HandType.FullHouse;
                }
                else if (this.HasFlush())
                {
                    return HandType.Flush;
                }
                else if (this.HasStraight())
                {
                    return HandType.Straight;
                }
                else if (this.HasThreeOfAKind())
                {
                    return HandType.ThreeOfAKind;
                }
                else if (this.HasTwoPair())
                {
                    return HandType.TwoPair;
                }
                else if (this.HasPair())
                {
                    return HandType.OnePair;
                }
                else
                {
                    return HandType.HighCard;
                }
            }
        }

        // Constructor that isn't used
        public PokerPlayer() 
        { 
        }
        public Card HighCard()
        {
            //orders the card by rank in descending order, then takes the first card which would be the highest card
            return playerHand.OrderByDescending(x => x.Rank).First();
        }

        public bool HasPair()
        {
            //groups the player hand by rank, checks to see if there is 2 of the same rank, but only for 1 pair
            return playerHand.GroupBy(x => x.Rank).Where(y => y.Count() == 2).Count() == 1;
        }
        public bool HasTwoPair()
        {
            //groups by rank and checks if there is something on the same rank and if it happens twice
            return playerHand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }
        public bool HasThreeOfAKind()
        {
            //grouping by rank and then checking if there is a list created with three of the same rank
            return playerHand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1;
        }
        public bool HasStraight()
        {
            //ordering by rank and checking if they are all different ranks, then seeing if the difference between the first and last is 4
            if (playerHand.OrderByDescending(x => x.Rank).First().Rank.Equals(14))
            {
                return (playerHand.Distinct().OrderBy(x => x.Rank).First().Rank) - (playerHand.Distinct().OrderBy(x => x.Rank).Take(4).Last().Rank) == 3;
            }
            return (playerHand.Distinct().OrderByDescending(x => x.Rank).First().Rank - playerHand.Distinct().OrderByDescending(x => x.Rank).Last().Rank) == 4;
        }
        public bool HasFlush()
        {
            //checking to make sure all the cards in hand are of the same suit
            return playerHand.GroupBy(x => x.Suit).Where(x => x.Count() == 5).Count() == 1;
        }
        public bool HasFullHouse()
        {
            //grouping the player hands by rank and checking if there is 1 pair and 1 three of a kind
            return playerHand.GroupBy(x => x.Rank).Where(y => y.Count() == 2).Count() == 1 && playerHand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1;
        }
        public bool HasFourOfAKind()
        {
            //grouping by rank and checking if there is 4 of the same rank, also making sure they are all different suits
            return playerHand.GroupBy(x => x.Suit).Distinct().Count() == 4 && playerHand.GroupBy(x=> x.Rank).Where(x => x.Count() == 4).Count() == 1;
        }
        public bool HasStraightFlush()
        {
            //grouping by suit and making sure all cards in hard are same suit, then checking to see if they are in order by rank as well
            return playerHand.GroupBy(x => x.Suit).Where(x => x.Count() == 5).Count() == 1 && HasStraight();
        }
        public bool HasRoyalFlush()
        {
            //checking to see if all cards are the same suit, then checking if they are in order and the top 5 values
            return playerHand.GroupBy(x => x.Suit).Where(x => x.Count() == 5).Count() == 1 && HasStraight() && (int)playerHand.OrderByDescending(x => x.Rank).First().Rank == 14;
        }

    }
    //Guides to pasting your Deck and Card class

    //  *****Deck Class Start*****
    class Deck
    {
        public int CardsRemaining
        {
            get
            {
                return DeckOfCards.Count();
            }
        }

        public List<Card> DeckOfCards;
        public List<Card> DiscardedCards;

        //calls number of decks
        public Deck()
            : this(1)
        {

        }

        public Deck(int numberOfDecks)
        {
            DeckOfCards = new List<Card>();
            DiscardedCards = new List<Card>();

            int suitCounter = 1;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    DeckOfCards.Add(new Card(j, i));
                }
                suitCounter++;
            }
        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> dealtCards = DeckOfCards.Take(numberOfCards).ToList<Card>();
            foreach (Card oneCard in dealtCards)
            {
                DeckOfCards.Remove(oneCard);
            }
            return dealtCards;
        }

        public void Shuffle()
        {
            Random rng = new Random();
            List<Card> tempDeck = new List<Card>();

            if (DeckOfCards.Count > 0)
            {
                Card tempCard = DeckOfCards.ElementAt(rng.Next(DeckOfCards.Count));
                DeckOfCards.Remove(tempCard);
                tempDeck.Add(tempCard);
            }
            DeckOfCards = tempDeck;
        }

        public void Discard(List<Card> cards)
        {
            DiscardedCards = new List<Card>();

            foreach (Card oneCard in cards)
            {
                DeckOfCards.Remove(oneCard);
                DiscardedCards.Add(oneCard);
            }
        }

    }

    //  *****Deck Class End*******

    //  *****Card Class Start*****
    class Card
    {


        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(int rank, int suit)
        {

            this.Rank = (Rank)rank;
            this.Suit = (Suit)suit;
        }
    }
    public enum Suit
    {
        Heart,
        Diamond,
        Club,
        Spade
    }

    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
