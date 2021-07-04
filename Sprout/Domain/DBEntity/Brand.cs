using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class Brand
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

    }
}
