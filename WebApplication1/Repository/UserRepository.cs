using Seguradora.Model;
using Seguradora.Models;
using System.Collections.Generic;
using System.Linq;

namespace Seguradora.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SeguradoraContext _context;

        public UserRepository(SeguradoraContext context)
        {
            _context = context;
        }

        public void Delete(long id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {

            }

            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public HashSet<User> GetAll()
        {
            return new HashSet<User>(_context.User.ToList());
        }

        public User GetByAuth(Login auth)
        {
            return _context.User.SingleOrDefault(u => u.Email.Equals(auth.Username) && u.Password == User.GenerateHashPassword(auth.Password));
        }

        public User GetById(long id)
        {
            return _context.User.Find(id);
        }

        public User Save(User user)
        {
            user.Password = User.GenerateHashPassword(user.Password);

            if (user.Id > 0)
            {
                _context.User.Update(user);
            }
            else
            {
                _context.User.Add(user);
            }
            _context.SaveChanges();

            return user;
        }
    }
}
