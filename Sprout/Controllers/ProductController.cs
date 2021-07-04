using Microsoft.AspNetCore.Mvc;
using Sprout.Services.Interfaces;
using Sprout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Controllers
{
    [Route(WebAPI.Product)]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _products;

        public ProductController(IProductService products)
        {
            _products = products;
        }

        [HttpGet("all")]
        public IActionResult Products()
        {
            return new JsonResult(_products.GetProducts().ToDto());
        }

        [HttpGet("get-discounted")]
        public IActionResult GetDuscountedProducts()
        {
            return new JsonResult(_products.GetDiscountedProducts());
        }

        [HttpGet("get-new-additions")]
        public IActionResult GetNewAdditions()
        {
            return new JsonResult(_products.GetNewAdditions(20));
        }
        
    }
}
