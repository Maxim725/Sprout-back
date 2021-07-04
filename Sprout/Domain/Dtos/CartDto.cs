using Sprout.Domain.DBEntity;
using Sprout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.Dtos
{
    public sealed class CartDto
    {
        public ICollection<CartItemDto> CartItems { get; set; }

        //public CartDto(Cart cart)
        //{
        //    var list = cart.CartItems?.Select(e => e.ToDto());
        //    CartItems = list.ToList();
        //}
    }
}
