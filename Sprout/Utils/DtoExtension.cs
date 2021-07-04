using Sprout.Domain.DBEntity;
using Sprout.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Utils
{
    public static class DtoExtension
    {
        public static CartItemDto ToDto(this CartItem cartItem)
        {
            return new CartItemDto
            {
                ProductId = cartItem.Product.Id,
                Quantity = cartItem.Quantity
            };
        }

        public static CartDto ToDto(this Cart cart)
        {
            return new CartDto
            {
                CartItems = cart.CartItems.Select(i => i.ToDto()).ToList()
            };
        }

        public static ICollection<ProductDto> ToDto(this ICollection<Product> products)
        {
            var  temp = products.Select(el =>
            {
                return el.ToDto();
            });

            return temp.ToList();
        }

        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Brand = product.Brand,
                CategoriesId = product.Categories.Select(el => el.Id).ToList(),
                Comments = product.Comments,
                Composition = product.Composition,
                Country = product.Country,
                Delivery = product.Delivery,
                Descriptions = product.Descriptions,
                Discount = product.Discount,
                Img = product.Img,
                IsInStock = product.IsInStock,
                Price = product.Price,
                Raiting = product.Raiting,
                Vitamins = product.Vitamins,
                Title = product.Title,
                Volume = product.Volume
            };
        }
    }
}
