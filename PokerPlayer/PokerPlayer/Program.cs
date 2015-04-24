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
        public PokerPlayer() { }
        public bool HasPair()
        {
            return playerHand.GroupBy(x => x.Rank).Where(y => y.Count() == 2).Count() == 1;
        }
        public bool HasTwoPair()
        {
            return playerHand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }
        public bool HasThreeOfAKind()
        {
            return playerHand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1;
        }
        public bool HasStraight()
        {
            foreach (var straight in playerHand)
            {
                
            }
            return false;
        }
        public bool HasFlush()
        {

            return playerHand.GroupBy(x => x.Suit).Where(x => x.Count() == 3).Count() == 1;
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
        
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }

        public Card(CardRank rank, CardSuit suit)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }
 public enum CardSuit
 {
     Heart,
     Diamond,
     Club,
     Spade
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

    //  *****Card Class End*******
}
