using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.DB
{
    public sealed class UserRepository : IUserReposritory
    {
        private readonly SproutContext _context;
        public UserRepository(SproutContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            var findUser = _context.Users.FirstOrDefault(u => u.Email.Equals(user.Email) || u.Phone.Equals(user.Phone));

            if(findUser == null)
            {
                _context.Users.Add(user);
                user.Id = _context.SaveChanges();

                return user;
            }

            throw new ApplicationException("Такой пользователь существует");
            
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
