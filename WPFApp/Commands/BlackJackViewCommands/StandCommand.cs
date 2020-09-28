using System;
using System.Windows.Input;
using WPFApp.GameCommunications;

namespace WPFApp.Commands.BlackJackViewCommands
{
    public class StandCommand : ICommand
    {
        private readonly BlackJackCommunication _blackJackCommunication;

        public StandCommand(BlackJackCommunication blackJackCommunication)
        {
            _blackJackCommunication = blackJackCommunication;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _blackJackCommunication.Stand();
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}