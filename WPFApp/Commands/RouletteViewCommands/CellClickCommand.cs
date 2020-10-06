using System;
using System.Windows.Input;

namespace WPFApp.Commands.RouletteViewCommands
{
    public class CellClickCommand : ICommand
    {
        private readonly Action<object> _action;

        public CellClickCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}