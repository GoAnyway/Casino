using System;
using System.Windows.Input;
using WPFApp.ViewModels;

namespace WPFApp.Commands.BlackJackViewCommands
{
    public class CancelBetCommand : ICommand
    {
        private readonly BlackJackViewModel _blackJackViewModel;

        public CancelBetCommand(BlackJackViewModel blackJackViewModel)
        {
            _blackJackViewModel = blackJackViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _blackJackViewModel.HasBetCancelled = true;
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}