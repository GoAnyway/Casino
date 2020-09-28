using System.Collections.Generic;
using Database.Context;
using Database.Entities;

namespace Database.Repository
{
    public class CasinoRepository : ICasinoRepository
    {
        private readonly UserContext _context;

        public CasinoRepository(UserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Set<User>();
        }

        public void Save(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }
    }
}