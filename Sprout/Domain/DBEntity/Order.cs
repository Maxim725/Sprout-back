using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class Order
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public User User { get; set; }

        [Required]
        ICollection<Product> Products { get; set; }
        
        [Required]
        ICollection<int> Quantities { get; set; }
    }
}
