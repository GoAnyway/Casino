using Database.Entities;
using WPFApp.ViewModels;

namespace WPFApp.DataManager.Mapper
{
    public class UserMapper : AbstractMapper<User, UserViewModel>
    {
        public override UserViewModel MapTo(User source)
        {
            return new UserViewModel
            {
                Id = source.Id,
                Username = source.Username,
                Password = source.Password,
                Nickname = source.Nickname,
                Balance = source.Balance
            };
        }

        public override User MapFrom(UserViewModel destination)
        {
            return new User
            {
                Id = destination.Id,
                Username = destination.Username,
                Password = destination.Password,
                Nickname = destination.Nickname,
                Balance = destination.Balance
            };
        }
    }
}