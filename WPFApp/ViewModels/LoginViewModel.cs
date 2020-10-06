using System.Windows.Input;
using System.Windows.Media;
using WPFApp.Commands.LoginViewCommands;
using WPFApp.DataManager;
using WPFApp.Logic.Login;
using WPFApp.Views;

namespace WPFApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly LoginView _loginView;

        private Brush _foregroundColor = Brushes.Red;

        private string _resultOfLoginTry;

        public LoginViewModel(LoginView loginView, CasinoDataManager dataManager)
        {
            _loginView = loginView;
            LoginCommand = new LoginCommand(this, new LoginVerifier(dataManager));
        }

        public bool DialogResult
        {
            set => _loginView.DialogResult = value;
        }

        public string ResultOfLoginTry
        {
            get => _resultOfLoginTry;
            set
            {
                _resultOfLoginTry = value;
                OnPropertyChanged();
            }
        }

        public Brush ForegroundColor
        {
            get => _foregroundColor;
            set
            {
                _foregroundColor = value;
                OnPropertyChanged();
            }
        }

        public string Login => _loginView.Login;
        public string Password => _loginView.Password;

        public ICommand LoginCommand { get; set; }

        public void ClearPassword()
        {
            _loginView.LoginPasswordBox.Clear();
        }
    }
}