using AutoMapper;
using Database.Entities;
using Models;
using WPFApp.ViewModels;

namespace WPFApp.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, UserModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname));
            CreateMap<UserModel, UserViewModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname));

            CreateMap<User, UserModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname));
            CreateMap<UserModel, User>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.Nickname, opt => opt.MapFrom(s => s.Nickname));
        }
    }
}