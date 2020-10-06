using System;
using System.Windows.Input;
using WPFApp.ViewModels;

namespace WPFApp.Commands.MainViewCommands
{
    public class SwitchToRouletteViewModel : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        public SwitchToRouletteViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.SelectedViewModel = new RouletteViewModel();
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067
    }
}