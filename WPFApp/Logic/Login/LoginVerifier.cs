using System.Collections.Generic;
using System.Linq;
using WPFApp.DataManager;
using WPFApp.ViewModels;

namespace WPFApp.Logic.Login
{
    public class LoginVerifier
    {
        private readonly IEnumerable<UserViewModel> _users;

        public LoginVerifier(ICasinoDataManager manager)
        {
            _users = manager.GetAll();
        }

        public UserViewModel VerifyUser(string username, string password)
        {
            return _users.FirstOrDefault(_ => _.Username == username &&
                                              _.Password == password);
        }
    }
}