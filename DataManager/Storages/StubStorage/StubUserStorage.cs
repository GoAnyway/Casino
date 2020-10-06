using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DataManager.Storages.StubStorage
{
    public class StubUserStorage : IUserStorage // for tests
    {
        private readonly IList<UserModel> _users;

        public StubUserStorage()
        {
            _users = new List<UserModel>
            {
                new UserModel
                {
                    Id = Guid.NewGuid(), Username = "User", Password = "1234", Balance = 1500, Nickname = "BestPlayer"
                },
                new UserModel
                {
                    Id = Guid.NewGuid(), Username = "User2", Password = "4321", Balance = 5600, Nickname = "BestPlayer2"
                }
            };
        }

        public async Task<UserResultModel> GetUserById(Guid id)
        {
            var result = new UserResultModel
            {
                Success = true
            };
            var user = _users.FirstOrDefault(_ => _.Id == id);
            if (user == null)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = 1001,
                    ErrorMessage = "User is not found"
                };
            }
            else
            {
                result.User = user;
            }

            return result;
        }

        public async Task<AuthenticationResultModel> Authenticate(UserModel model)
        {
            var result = new AuthenticationResultModel();
            var hash = model.Password;

            var user = _users.FirstOrDefault(_ => _.Username == model.Username &&
                                                  _.Password == hash);

            if (user == null)
            {
                result.Success = false;
                result.Error = new ErrorModel
                {
                    Code = 1002,
                    ErrorMessage = "Incorrect login or password"
                };
            }
            else
            {
                result.User = user;
                result.Success = true;
            }

            return result;
        }

        public async Task<RegistrationResultModel> Register(UserModel model)
        {
            return await Task.FromResult(new RegistrationResultModel
            {
                Success = true,
                UserId = Guid.NewGuid()
            });
        }
    }
}