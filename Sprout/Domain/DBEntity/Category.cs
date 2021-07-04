using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class Category
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
