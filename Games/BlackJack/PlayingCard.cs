namespace Games.BlackJack
{
    public class PlayingCard
    {
        public enum CardRank
        {
            Ace = 1,
            Deuce,
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
            King
        }

        public enum CardSuit
        {
            Diamonds,
            Clubs,
            Hearts,
            Spades
        }

        public PlayingCard(CardRank rank, CardSuit suit, int weight)
        {
            Rank = rank;
            Suit = suit;
            Worth = weight;
        }

        public CardRank Rank { get; set; }
        public int Worth { get; set; }
        public CardSuit Suit { get; set; }
    }
}