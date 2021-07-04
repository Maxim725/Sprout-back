using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.Dtos
{
    public class UpdateCartItemDto : CartItemDto
    {
        [Required]
        public bool Increase { get; set; }
    }
}
