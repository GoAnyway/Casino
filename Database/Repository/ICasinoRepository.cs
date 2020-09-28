using System.Collections.Generic;
using Database.Entities;

namespace Database.Repository
{
    public interface ICasinoRepository
    {
        IEnumerable<User> GetAll();
        void Save(User person);
    }
}