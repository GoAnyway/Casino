using System.Windows;
using System.Windows.Input;
using WPFApp.Commands.BlackJackViewCommands;
using WPFApp.GameCommunications;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class BlackJackViewModel : BaseViewModel
    {
        private readonly BlackJackCommunication _blackJackCommunication;
        private string _betResult = string.Empty;

        private Visibility _betStackPanelVisibility;
        private string _betTimer = string.Empty;

        private Visibility _gameStackPanelVisibility = Visibility.Hidden;

        public BlackJackViewModel(BlackJackView blackJackView)
        {
            _blackJackCommunication = new BlackJackCommunication(blackJackView);

            _blackJackCommunication.GameHasChangedState += (sender, args) =>
            {
                if (_blackJackCommunication.GameInProgress)
                {
                    BetStackPanelVisibility = Visibility.Hidden;
                    GameStackPanelVisibility = Visibility.Visible;
                }
                else
                {
                    BetStackPanelVisibility = Visibility.Visible;
                    GameStackPanelVisibility = Visibility.Hidden;
                }
            };
            _blackJackCommunication.PropertyChanged += (sender, args) =>
                OnPropertyChanged(args.PropertyName);

            BetCommand = new BetCommand(this, _blackJackCommunication);
            CancelBetCommand = new CancelBetCommand(this);
            StandCommand = new StandCommand(_blackJackCommunication);
            HitCommand = new HitCommand(_blackJackCommunication);
        }

        public BlackJackViewModel()
        {
        }

        public string PlayerScore => _blackJackCommunication.PlayerScore != 0
            ? _blackJackCommunication.PlayerScore.ToString()
            : string.Empty;

        public string DealerScore => _blackJackCommunication.DealerScore != 0
            ? _blackJackCommunication.DealerScore.ToString()
            : string.Empty;

        public string GameResult => _blackJackCommunication.GameResult;

        public Visibility BetStackPanelVisibility
        {
            get => _betStackPanelVisibility;
            set
            {
                _betStackPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility GameStackPanelVisibility
        {
            get => _gameStackPanelVisibility;
            set
            {
                _gameStackPanelVisibility = value;
                OnPropertyChanged();
            }
        }

        public string BetValue { get; set; }

        public bool HasBetCancelled { get; set; }

        public string BetResult
        {
            get => _betResult;
            set
            {
                _betResult = value;
                OnPropertyChanged();
            }
        }

        public string BetTimer
        {
            get => _betTimer;
            set
            {
                _betTimer = value;
                OnPropertyChanged();
            }
        }

        public ICommand BetCommand { get; }
        public ICommand CancelBetCommand { get; }
        public ICommand StandCommand { get; }
        public ICommand HitCommand { get; }
    }
}