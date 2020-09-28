using System.Collections.Generic;
using WPFApp.ViewModels;

namespace WPFApp.DataManager
{
    public interface ICasinoDataManager
    {
        IEnumerable<UserViewModel> GetAll();
        void Save(UserViewModel userViewModel);
    }
}