using System.Collections.Generic;
using System.Linq;
using Database.Entities;
using Database.Repository;
using WPFApp.DataManager.Mapper;
using WPFApp.ViewModels;

namespace WPFApp.DataManager.Managers.DbManager
{
    public class DbCasinoManager : ICasinoDataManager
    {
        private readonly AbstractMapper<User, UserViewModel> _mapper;
        private readonly ICasinoRepository _repository;

        public DbCasinoManager(ICasinoRepository repository, AbstractMapper<User, UserViewModel> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _repository.GetAll().Select(user => _mapper.MapTo(user));
        }

        public void Save(UserViewModel model)
        {
            _repository.Save(_mapper.MapFrom(model));
        }
    }
}