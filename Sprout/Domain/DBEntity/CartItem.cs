using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public class CartItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Product Product { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}
