using Sprout.Domain.DBEntity;
using Sprout.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Services.Interfaces
{
    public interface ICartService
    {
        public Cart GetCart(int userId);
        public CartDto GetCartDto(int userId);

        public bool AddCartItem(int userId, long productId, int quantity);
        public bool UpdateCartItem(int userId, long productId, int quantity, bool increase);
        public bool DeleteCartItem(int userId, long productId);
    }
}
