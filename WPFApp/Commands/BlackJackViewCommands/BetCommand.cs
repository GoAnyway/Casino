using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFApp.GameCommunications;
using WPFApp.Logic.Bet;
using WPFApp.ViewModels;

namespace WPFApp.Commands.BlackJackViewCommands
{
    public class BetCommand : ICommand
    {
        private readonly BetVerifier _betVerifier = new BetVerifier();
        private readonly BlackJackCommunication _blackJackCommunication;
        private readonly BlackJackViewModel _blackJackViewModel;
        private bool _hasBet;

        public BetCommand(BlackJackViewModel blackJackViewModel, BlackJackCommunication blackJackCommunication)
        {
            _blackJackViewModel = blackJackViewModel;
            _blackJackCommunication = blackJackCommunication;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var isBetCorrect = _betVerifier.VerifyBet(_blackJackViewModel.BetValue);
            if (isBetCorrect)
            {
                if (_hasBet || _blackJackCommunication.GameInProgress) return;

                var bet = int.Parse(_blackJackViewModel.BetValue);

                _hasBet = true;
                _blackJackViewModel.HasBetCancelled = false;

                for (var i = 5; i >= 0 && !_blackJackViewModel.HasBetCancelled; i--)
                {
                    _blackJackViewModel.BetTimer = i.ToString();
                    await Task.Delay(1000);
                }

                if (_blackJackViewModel.HasBetCancelled)
                {
                    _hasBet = false;
                    _blackJackViewModel.BetTimer = string.Empty;
                    _blackJackViewModel.BetResult = string.Empty;
                    return;
                }

                _hasBet = false;
                _blackJackViewModel.BetTimer = string.Empty;

                _blackJackViewModel.BetResult = $"Your bet: {bet}";
                _blackJackCommunication.StartGame(bet);
            }
            else
            {
                _blackJackViewModel.BetResult = string.Empty;
                await Task.Delay(100);
                _blackJackViewModel.BetResult = "Wrong bet. Bet must be at least 100 coins";
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}