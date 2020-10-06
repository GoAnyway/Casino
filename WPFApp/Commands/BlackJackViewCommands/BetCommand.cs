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
            if (_hasBet || _blackJackCommunication.GameInProgress) return;

            var isBetCorrect = _betVerifier.VerifyBet(_blackJackViewModel.BetValue);
            if (isBetCorrect)
            {
                _hasBet = true;
                var bet = int.Parse(_blackJackViewModel.BetValue);
                _blackJackViewModel.HasBetCancelled = false;

                for (var i = 50; i >= 0 && !_blackJackViewModel.HasBetCancelled; i--)
                {
                    if (i % 10 == 0)
                    {
                        _blackJackViewModel.BetTimer = (i / 10).ToString();
                    }

                    await Task.Delay(100);
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