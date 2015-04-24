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

        public Deck()
            : this(1)
        {

        }
        public Deck(int numberOfDecks)
        {
            DeckOfCards = new List<Card>();
            DiscardedCards = new List<Card>();
            for (int k = 0; k < numberOfDecks; k++)
            {
                //Init deck with 52 cards
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 2; j < 15; j++)
                    {
                        DeckOfCards.Add(new Card((Card.CardRank)j, (Card.CardSuit)i));
                    }
                }
            }

        }

        public void Discard(List<Card> cards)
        {
            foreach (Card oneCard in cards)
            {
                DeckOfCards.Remove(oneCard);
                DiscardedCards.Add(oneCard);
            }
        }
        public void Discard(Card card)
        {
            DeckOfCards.Remove(card);
            DiscardedCards.Add(card);
        }

        public List<Card> Deal(int numberOfCards)
        {
            // Get cards to deal
            List<Card> dealtCards = DeckOfCards.Take(numberOfCards).ToList<Card>();
            // Remove each card from the DeckOfCards
            foreach (Card oneCard in dealtCards)
            {
                DeckOfCards.Remove(oneCard);
            }
            // return dealt cards
            return dealtCards;
        }
        public void Shuffle()
        {
            Random rng = new Random();
            List<Card> tempDeck = new List<Card>();

            // While the deck has cards
            while (DeckOfCards.Count > 0)
            {
                // Pick random card
                Card tempCard = DeckOfCards.ElementAt(rng.Next(DeckOfCards.Count));
                // Remove random card from deck
                DeckOfCards.Remove(tempCard);
                // Add it to temp deck
                tempDeck.Add(tempCard);
            }
            // Set random card list to our Deck
            DeckOfCards = tempDeck;
        }
    }

    //  *****Deck Class End*******

    //  *****Card Class Start*****
 class Card
    {
        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum CardRank
        {
            two = 2,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            Jack,
            Queen,
            King,
            Ace
        }
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }

        public Card(Card.CardRank rank, Card.CardSuit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }


    //  *****Card Class End*******
}
