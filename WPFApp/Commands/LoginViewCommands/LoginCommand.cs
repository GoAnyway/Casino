using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Utils;
using WPFApp.Logic.Login;
using WPFApp.UserData;
using WPFApp.ViewModels;

namespace WPFApp.Commands.LoginViewCommands
{
    public class LoginCommand : NotifyChanged, ICommand
    {
        private readonly LoginVerifier _loginVerifier;
        private readonly LoginViewModel _loginViewModel;
        private bool _isAuthorized;

        public LoginCommand(LoginViewModel loginViewModel, LoginVerifier loginVerifier)
        {
            _loginViewModel = loginViewModel;
            _loginVerifier = loginVerifier;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var login = _loginViewModel.Login;
            var password = _loginViewModel.Password;
            var authorizedUser = _loginVerifier.VerifyUser(login, password);

            if (authorizedUser != null)
            {
                if (!_isAuthorized)
                {
                    ChangeControlsState(true, authorizedUser.Nickname);

                    AuthorizedUserData.Instance.AuthorizedUser.Nickname = authorizedUser.Nickname;
                    AuthorizedUserData.Instance.AuthorizedUser.Balance = authorizedUser.Balance;

                    await Task.Delay(2000);
                    _loginViewModel.DialogResult = true;
                }
            }
            else
            {
                ChangeControlsState(false);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067

        private async void ChangeControlsState(bool isEntered, string nickname = "")
        {
            _loginViewModel.ResultOfLoginTry = string.Empty;
            await Task.Delay(100);

            if (isEntered)
            {
                _isAuthorized = true;
                _loginViewModel.ForegroundColor = Brushes.Green;
                _loginViewModel.ResultOfLoginTry = $"Welcome again, {nickname}!";
            }
            else
            {
                _loginViewModel.ClearPassword();
                _loginViewModel.ResultOfLoginTry = "Login failed. Please try again";
            }
        }
    }
}