using System.Collections.ObjectModel;
using System.Linq;
using Games.GameStates;

namespace Games.BlackJack
{
    public class BlackJackGame : Game
    {
        private readonly Deck _deck = new Deck();

        private PlayingCard _hiddenDealerCard;

        public ObservableCollection<PlayingCard> DealerCards =
            new ObservableCollection<PlayingCard>();

        public ObservableCollection<PlayingCard> PlayerCards =
            new ObservableCollection<PlayingCard>();

        public BlackJackGame()
        {
            PlayerCards.CollectionChanged += (sender, args) =>
            {
                var newItems = args.NewItems?.OfType<PlayingCard>().ToList();
                if (newItems?.Any() == true)
                    foreach (var item in newItems)
                        PlayerScore += item.Worth;
                OnPropertyChanged(nameof(PlayerScore));
            };
            DealerCards.CollectionChanged += (sender, args) =>
            {
                var newItems = args.NewItems?.OfType<PlayingCard>().ToList();
                if (newItems?.Any() == true)
                    foreach (var item in newItems)
                        DealerScore += item.Worth;
                OnPropertyChanged(nameof(DealerScore));
            };
        }

        public int PlayerScore { get; private set; }
        public int DealerScore { get; private set; }

        public override void StartGame()
        {
            PlayerCards.Clear();
            DealerCards.Clear();
            PlayerScore = 0;
            DealerScore = 0;

            CreateDeck();
            DealStartingCards();
        }

        public override BaseGameResult GetResult()
        {
            if (DealerScore == 21)
                return new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Loss};

            if (PlayerScore == 21)
                return new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Win};

            if (DealerScore == PlayerScore)
                return new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Draw};

            if (DealerScore < 21 && PlayerScore < 21 && DealerScore > PlayerScore)
                return new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Loss};

            if (DealerScore < 21 && PlayerScore < 21 && PlayerScore > DealerScore)
                return new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Win};

            return DealerScore > 21
                ? new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Win}
                : new BlackJackGameResult
                    {Result = BlackJackGameResult.BlackJackResult.Loss};
        }

        internal override void GoToNextState()
        {
            TransitionToState(HasAnyoneFinished()
                ? (AbstractState) new FinishState()
                : new WaitingState());
        }

        public void DealerPlays()
        {
            ShowHiddenCard();
            while (!HasAnyoneFinished() && DealerScore < 17) DealerTakesCard();
            GoToFinishState();
        }

        public bool HasAnyoneFinished()
        {
            return DealerScore >= 21 ||
                   PlayerScore >= 21;
        }

        public void PlayerTakesCard()
        {
            PlayerCards.Add(_deck.DrawCard());
        }

        private void DealStartingCards()
        {
            PlayerTakesCard();
            PlayerTakesCard();
            DealerTakesCard();
            _hiddenDealerCard = _deck.DrawCard();
        }

        private void CreateDeck()
        {
            _deck.CreateAndShuffleDeck();
        }

        private void ShowHiddenCard()
        {
            DealerCards.Add(_hiddenDealerCard);
        }

        private void DealerTakesCard()
        {
            DealerCards.Add(_deck.DrawCard());
        }
    }
}