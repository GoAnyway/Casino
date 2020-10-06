using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly UserContext _context;

        private bool _disposed;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async void Create(User item)
        {
            await _context.Users.AddAsync(item);
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public async void Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}