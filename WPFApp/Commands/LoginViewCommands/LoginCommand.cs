using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Models;
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
            if (_isAuthorized) return;

            var login = _loginViewModel.Login;
            var password = _loginViewModel.Password;
            var resultOfLoginTry = await _loginVerifier.VerifyUser(login, password);

            if (resultOfLoginTry.Success)
            {
                _isAuthorized = true;
                ChangeControlsState(true, resultOfLoginTry);

                AuthorizedUserData.Instance.AuthorizedUser.Nickname = resultOfLoginTry.User.Nickname;
                AuthorizedUserData.Instance.AuthorizedUser.Balance = resultOfLoginTry.User.Balance;

                await Task.Delay(2000);
                _loginViewModel.DialogResult = true;
            }
            else
            {
                ChangeControlsState(false, resultOfLoginTry);
            }
        }

#pragma warning disable CS0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067

        private async void ChangeControlsState(bool isEntered, AuthenticationResultModel result)
        {
            _loginViewModel.ResultOfLoginTry = string.Empty;
            await Task.Delay(100);

            if (isEntered)
            {
                _loginViewModel.ForegroundColor = Brushes.Green;
                _loginViewModel.ResultOfLoginTry = $"Welcome again, {result.User.Nickname}!";
            }
            else
            {
                _loginViewModel.ClearPassword();
                _loginViewModel.ResultOfLoginTry = result.Error.ErrorMessage;
            }
        }
    }
}