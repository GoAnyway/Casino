using System.Threading.Tasks;
using AutoMapper;
using DataManager.Storages;
using Models;
using WPFApp.ViewModels;

namespace WPFApp.DataManager
{
    public class CasinoDataManager
    {
        private readonly Mapper _mapper;
        private readonly IUserStorage _userStorage;

        public CasinoDataManager(IUserStorage userStorage, Mapper mapper)
        {
            _userStorage = userStorage;
            _mapper = mapper;
        }

        public async Task<AuthenticationResultModel> GetResultOfLoginTry(UserViewModel userViewModel)
        {
            var user = _mapper.Map<UserModel>(userViewModel);

            return await _userStorage.Authenticate(user);
        }
    }
}