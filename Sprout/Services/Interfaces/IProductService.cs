using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Services.Interfaces
{
    public interface IProductService
    {
        public ICollection<Product> GetProducts();
        public ICollection<Product> GetDiscountedProducts();
        public bool CreateProducts(Product product);
        public bool UpdateProduct(Product product);

        public ICollection<Product> GetNewAdditions(int count);
    }
}
