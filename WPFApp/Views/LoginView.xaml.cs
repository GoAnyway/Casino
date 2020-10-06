using System.Windows.Input;
using WPFApp.DataManager;
using WPFApp.ViewModels;

namespace WPFApp.Views
{
    public partial class LoginView
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginView(CasinoDataManager dataManager)
        {
            InitializeComponent();
            var loginViewModel = new LoginViewModel(this, dataManager);
            _loginViewModel = loginViewModel;
            DataContext = loginViewModel;
        }

        public string Login => LoginTextBox.Text;
        public string Password => LoginPasswordBox.Password;

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) _loginViewModel.LoginCommand.Execute(sender);
        }
    }
}