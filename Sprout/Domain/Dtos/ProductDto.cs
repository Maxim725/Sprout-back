using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Domain.Dtos
{
    public sealed class ProductDto
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
        public ICollection<long> CategoriesId { get; set; }

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

    }
}
