using System;
using System.Threading.Tasks;
using Models;

namespace DataManager.Storages
{
    public interface IUserStorage
    {
        Task<UserResultModel> GetUserById(Guid id);
        Task<AuthenticationResultModel> Authenticate(UserModel user);
        Task<RegistrationResultModel> Register(UserModel model);
    }
}