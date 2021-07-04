using Microsoft.EntityFrameworkCore;
using Sprout.DB;
using Sprout.Domain.DBEntity;
using Sprout.Domain.Dtos;
using Sprout.Services.Interfaces;
using Sprout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Services
{
    public sealed class CartService : ICartService
    {
        private readonly SproutContext _context;

        public CartService(SproutContext context)
        {
            _context = context;
        }

        public Cart GetCart(int userId)
        {
            var user = _context.Users
                               .Include(e => e.Cart)
                               .ThenInclude(e => e.CartItems)
                               .ThenInclude(e => e.Product)
                               .FirstOrDefault(u => u.Id.Equals(userId));

            if(user != null)
            {
                return user.Cart;
            }

            return null;
        }

        public CartDto GetCartDto(int userId)
        {
            var user = _context.Users
                               .Include(e => e.Cart)
                               .ThenInclude(e => e.CartItems)
                               .ThenInclude(e => e.Product)
                               .FirstOrDefault(u => u.Id.Equals(userId));

            if (user != null)
            {
                return user.Cart.ToDto();
            }
            
            return null;
        }

        public bool AddCartItem(int userId, long productId, int quantity)
        {
            var user = _context.Users
                    .Include(u => u.Cart)
                    .ThenInclude(e => e.CartItems)
                    .FirstOrDefault(e => e.Id.Equals(userId));
            
            var product = _context.Products
                .FirstOrDefault(p => p.Id.Equals(productId));
            
            if(user != null && product != null)
            {
                user.Cart.CartItems.Add(new CartItem { Product = product, Quantity = quantity });
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool UpdateCartItem(int userId, long productId, int quantity, bool increase)
        {
            var user = _context.Users
                    .Include(u => u.Cart)
                    .ThenInclude(e => e.CartItems)
                    .ThenInclude(e => e.Product)
                    .FirstOrDefault(e => e.Id.Equals(userId));

            if (user == null)
                return false;

            var cartItem = user.Cart.CartItems
                    .FirstOrDefault(i => i.Product.Id.Equals(productId));

            if(cartItem != null)
            {
                if(increase)
                    cartItem.Quantity += quantity;
                else
                    cartItem.Quantity -= quantity;

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCartItem(int userId, long productId)
        {
            var user = _context.Users
                   .Include(u => u.Cart)
                   .ThenInclude(e => e.CartItems)
                   .ThenInclude(e => e.Product)
                   .FirstOrDefault(e => e.Id.Equals(userId));

            if (user == null)
                return false;

            var cartItem = user.Cart.CartItems
                   .FirstOrDefault(i => i.Product.Id.Equals(productId));

            if(cartItem != null)
            {
                user.Cart.CartItems.Remove(cartItem);
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();

                return true;
            }

            return false;
            
        }

    }
}
