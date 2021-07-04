using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.DB
{
    public interface IUserReposritory
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}
