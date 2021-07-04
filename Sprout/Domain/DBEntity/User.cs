using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{
    public sealed class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Cart Cart { get; set; }
    }
}
