using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.Dtos
{
    public class CartItemDto
    {
        [Required]
        public long ProductId { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}
