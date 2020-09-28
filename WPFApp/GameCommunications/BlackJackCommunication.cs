using System;
using System.Linq;
using Games;
using Games.BlackJack;
using Games.BlackJack.BlackJackStates;
using Games.GameStates;
using WPFApp.Views;

namespace WPFApp.GameCommunications
{
    public class BlackJackCommunication : GameCommunication
    {
        private readonly BlackJackGame _blackJack = new BlackJackGame();
        private readonly BlackJackView _blackJackView;
        private string _gameResult;

        public BlackJackCommunication(BlackJackView blackJackView)
        {
            _blackJackView = blackJackView;
            _blackJack.PropertyChanged += (sender, args) =>
                OnPropertyChanged(args.PropertyName);

            _blackJack.PlayerCards.CollectionChanged += (sender, args) =>
            {
                var newCards = args.NewItems?.OfType<PlayingCard>().ToList();

                if (newCards?.Any() != true) return;

                foreach (var card in newCards) _blackJackView.DrawCards(card, "Player");
            };
            _blackJack.DealerCards.CollectionChanged += (sender, args) =>
            {
                var newCards = args.NewItems?.OfType<PlayingCard>().ToList();

                if (newCards?.Any() != true) return;
                foreach (var card in newCards) _blackJackView.DrawCards(card, "Dealer");
            };

            _blackJack.GameIsFinished += GetGameResult;
        }

        public int PlayerScore => _blackJack.PlayerScore;
        public int DealerScore => _blackJack.DealerScore;

        public override string GameResult
        {
            get => _gameResult;
            set
            {
                _gameResult = value;
                OnPropertyChanged();
            }
        }

        public bool GameInProgress { get; set; }

        public override void StartGame(int bet)
        {
            GameResult = string.Empty;
            Bet = bet;

            if (_blackJack.CurrentState == null ||
                _blackJack.CurrentState is FinishState)
            {
                GameInProgress = true;
                GameHasChangedState?.Invoke(this, EventArgs.Empty);

                _blackJackView.ClearDrawnCards();
                _blackJack.TransitionToState(new StartState());
            }
        }

        public void Stand()
        {
            if (_blackJack.CurrentState is WaitingState)
                _blackJack.TransitionToState(new StandState());
        }

        public void Hit()
        {
            if (_blackJack.CurrentState is WaitingState)
                _blackJack.TransitionToState(new HitState());
        }

        protected override void GetGameResult(BaseGameResult result)
        {
            switch (result.Message)
            {
                case "Win":
                    GameResult = $"You've won {Bet * 2} coins!";
                    IncreaseBalance();
                    break;

                case "Loss":
                    DecreaseBalance();
                    break;
            }

            GameInProgress = false;
            GameHasChangedState?.Invoke(this, EventArgs.Empty);
        }

        internal event EventHandler GameHasChangedState;
    }
}