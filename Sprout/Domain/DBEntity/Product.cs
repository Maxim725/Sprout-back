using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.DBEntity
{

    public sealed class Product
    {   
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public float Raiting { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public uint Volume { get; set; }

        [Required]
        public Brand Brand { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; }
        
        [Required]
        public string Descriptions { get; set; }

        [Required]
        public string Composition { get; set; }
        
        [Required]
        public bool IsInStock { get; set; }

        [Required]
        public string Delivery { get; set; }
        
        public int Discount { get; set; }

        public ICollection<Vitamin> Vitamins { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Today;
    }
}
