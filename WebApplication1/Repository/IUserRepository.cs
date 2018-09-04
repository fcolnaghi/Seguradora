using Seguradora.Model;
using System.Collections.Generic;

namespace Seguradora.Repository
{
    public interface IUserRepository
    {
        User GetById(long id);
        User GetByAuth(Login auth);
        HashSet<User> GetAll();
        void Delete(long id);
        User Save(User user);
    }
}