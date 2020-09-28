using System;
using System.Windows.Input;
using WPFApp.GameCommunications;

namespace WPFApp.Commands.BlackJackViewCommands
{
    public class HitCommand : ICommand
    {
        private readonly BlackJackCommunication _blackJackCommunication;

        public HitCommand(BlackJackCommunication blackJackCommunication)
        {
            _blackJackCommunication = blackJackCommunication;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _blackJackCommunication.Hit();
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}