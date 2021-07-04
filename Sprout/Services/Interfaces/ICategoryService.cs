using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Services.Interfaces
{
    public interface ICategoryService
    {
        ICollection<Category> Get();
        Category Create(Category category);
        bool Delete();
    }
}
