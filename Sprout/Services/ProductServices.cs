using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprout.Domain.DBEntity;
using Sprout.Services.Interfaces;
using Sprout.DB;
using Microsoft.EntityFrameworkCore;

namespace Sprout.Services
{
    public class ProductServices : IProductService
    {
        private SproutContext _context;

        public ProductServices(SproutContext context)
        {
            _context = context;
        }

        public bool CreateProducts(Product product)
        {
            Product findProduct = _context.Products
                                          .FirstOrDefault((p) => p.Id == product.Id);
        
            if(findProduct != null)
            {
                return false;
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return true;
            }
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products
                .Include(p => p.Categories)
                //.Include(p => p.Brand)
                //.Include(p => p.Vitamins)
                //.Include(p => p.Country)
                //.Include(p => p.Comments)
                .ToList();
        }

        public bool UpdateProduct(Product product)
        {
            Product findProduct = _context.Products
                                          .FirstOrDefault((p) => p.Id == product.Id);

            if(findProduct != null)
            {
                findProduct = product;
                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        
        public ICollection<Product> GetDiscountedProducts()
        {
            return _context.Products
                           .Where(x => x.Discount > 0)
                           .ToList();
        }

        public ICollection<Product> GetNewAdditions(int count = -1)
        {
            return _context.Products
                           .OrderByDescending(x => x.CreatedAt)
                           .ThenByDescending(x => x.Raiting)
                           .Take(count)
                           .ToList();
        }

    }
}
