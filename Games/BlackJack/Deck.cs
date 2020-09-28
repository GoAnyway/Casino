using System;
using System.Collections.Generic;
using System.Linq;

namespace Games.BlackJack
{
    internal class Deck
    {
        private Stack<PlayingCard> _deck;

        public void CreateAndShuffleDeck()
        {
            var weights = new Dictionary<PlayingCard.CardRank, int>
            {
                [PlayingCard.CardRank.Ace] = 11,
                [PlayingCard.CardRank.Deuce] = 2,
                [PlayingCard.CardRank.Three] = 3,
                [PlayingCard.CardRank.Four] = 4,
                [PlayingCard.CardRank.Five] = 5,
                [PlayingCard.CardRank.Six] = 6,
                [PlayingCard.CardRank.Seven] = 7,
                [PlayingCard.CardRank.Eight] = 8,
                [PlayingCard.CardRank.Nine] = 9,
                [PlayingCard.CardRank.Ten] = 10,
                [PlayingCard.CardRank.Jack] = 10,
                [PlayingCard.CardRank.Queen] = 10,
                [PlayingCard.CardRank.King] = 10
            };

            IList<PlayingCard> cards = new List<PlayingCard>();

            foreach (PlayingCard.CardSuit suit in Enum.GetValues(typeof(PlayingCard.CardSuit)))
            foreach (PlayingCard.CardRank rank in Enum.GetValues(typeof(PlayingCard.CardRank)))
                cards.Add(new PlayingCard(rank, suit, weights[rank]));

            cards = cards.Select(_ => Enumerable.Repeat(_, 4)).SelectMany(_ => _).ToList();

            _deck = new Stack<PlayingCard>(cards.OrderBy(_ => Guid.NewGuid()));
        }

        public PlayingCard DrawCard()
        {
            return _deck.Pop();
        }
    }
}