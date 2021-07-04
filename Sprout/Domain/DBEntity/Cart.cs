using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class Cart
    {
        [Key]
        public long Id { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
