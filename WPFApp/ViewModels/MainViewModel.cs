using System.Windows.Input;
using WPFApp.Commands.MainViewCommands;
using WPFApp.UserData;

namespace WPFApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public MainViewModel()
        {
            AuthorizedUserData.Instance.AuthorizedUser = new UserViewModel();
            AuthorizedUserData.Instance.AuthorizedUser.PropertyChanged +=
                (sender, args) => OnPropertyChanged(args.PropertyName);

            SwitchToBlackJackViewModel = new SwitchToBlackJackViewModel(this);
            SwitchToRouletteViewModel = new SwitchToRouletteViewModel(this);
        }

        public string Nickname => AuthorizedUserData.Instance.AuthorizedUser.Nickname;
        public int Balance => AuthorizedUserData.Instance.AuthorizedUser.Balance;

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand SwitchToBlackJackViewModel { get; set; }
        public ICommand SwitchToRouletteViewModel { get; set; }
    }
}