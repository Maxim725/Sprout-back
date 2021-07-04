using Microsoft.AspNetCore.Mvc;
using Sprout.Domain.Dtos;
using Sprout.Services;
using Sprout.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Controllers
{
    [ApiController]
    [Route(WebAPI.Cart)]
    public class CartController : Controller
    {
        private readonly JwtService _jwtService;
        private readonly ICartService _cartService;

        public CartController(JwtService jwtService, ICartService cartService)
        {
            _jwtService = jwtService;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var cart = _cartService.GetCartDto(userId);

                return Ok(cart);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public IActionResult AddCartItem([FromBody]CartItemDto model)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                _cartService.AddCartItem(userId, model.ProductId, model.Quantity);

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        public IActionResult UpdateCartItem([FromBody]UpdateCartItemDto model)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                _cartService.UpdateCartItem(userId, model.ProductId, model.Quantity, model.Increase);

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpDelete("delete/{productId}")]
        public IActionResult DeleteCartItem(long productId)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                _cartService.DeleteCartItem(userId, productId);

                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}
