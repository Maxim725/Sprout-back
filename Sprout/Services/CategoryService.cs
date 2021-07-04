using Sprout.DB;
using Sprout.Domain.DBEntity;
using Sprout.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SproutContext _context;
        public CategoryService(SproutContext context)
        {
            _context = context;
        }

        public Category Create(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> Get()
        {
            return _context.Categories.ToList();
        }
    }
}
