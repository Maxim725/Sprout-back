using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class Country
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Nation { get; set; }
    }
}
