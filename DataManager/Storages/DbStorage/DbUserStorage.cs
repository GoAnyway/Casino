using System;
using System.Threading.Tasks;
using AutoMapper;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataManager.Storages.DbStorage
{
    public class DbUserStorage : IUserStorage // db
    {
        private readonly UserContext _context;
        private readonly Mapper _mapper;

        public DbUserStorage(UserContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserResultModel> GetUserById(Guid id)
        {
            var result = new UserResultModel
            {
                Success = true
            };
            var user = await _context.Users.FindAsync(id);
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
                result.User = _mapper.Map<UserModel>(user);
            }

            return result;
        }

        public async Task<AuthenticationResultModel> Authenticate(UserModel model)
        {
            var result = new AuthenticationResultModel();
            var hash = model.Password;

            var user = await _context.Users.FirstOrDefaultAsync(_ => _.Username == model.Username &&
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
                result.User = _mapper.Map<UserModel>(user);
                result.Success = true;
            }

            return result;
        }

        public async Task<RegistrationResultModel> Register(UserModel model)
        {
            if (await _context.Users.AnyAsync(_ => _.Username == model.Username))
            {
                return new RegistrationResultModel
                {
                    Success = false,
                    Error = new ErrorModel
                    {
                        Code = 1003,
                        ErrorMessage = "User with this username already exists"
                    }
                };
            }

            if (false) //  test
            {
                return new RegistrationResultModel
                {
                    Success = false,
                    Error = new ErrorModel
                    {
                        Code = 1004,
                        ErrorMessage = "Password is weak"
                    }
                };
            }

            var user = _mapper.Map<UserModel, User>(model);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new RegistrationResultModel
            {
                Success = true,
                UserId = user.Id
            };
        }
    }
}