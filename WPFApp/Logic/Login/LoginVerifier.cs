using System.Threading.Tasks;
using Models;
using WPFApp.DataManager;
using WPFApp.ViewModels;

namespace WPFApp.Logic.Login
{
    public class LoginVerifier
    {
        private readonly CasinoDataManager _manager;

        public LoginVerifier(CasinoDataManager manager)
        {
            _manager = manager;
        }

        public async Task<AuthenticationResultModel> VerifyUser(string username, string password)
        {
            var userForVerify = new UserViewModel {Username = username, Password = password};

            return await _manager.GetResultOfLoginTry(userForVerify);
        }
    }
}