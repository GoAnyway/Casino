using System;
using System.Collections.Generic;
using WPFApp.ViewModels;

namespace WPFApp.DataManager.Managers.TestManager
{
    public class TestCasinoManager : ICasinoDataManager
    {
        private List<UserViewModel> _testUserCollection;

        public IEnumerable<UserViewModel> GetAll()
        {
            var testUser = new UserViewModel
                {Balance = 1000, Id = 0, Nickname = "Hah123", Password = "1234", Username = "User"};
            var testUser2 = new UserViewModel
                {Balance = 1000, Id = 1, Nickname = "Aadajd", Password = "5555", Username = "User2"};

            _testUserCollection = new List<UserViewModel>
            {
                testUser,
                testUser2
            };

            return _testUserCollection;
        }

        public void Save(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }
    }
}