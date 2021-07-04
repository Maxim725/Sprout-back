using Microsoft.AspNetCore.Mvc;
using Sprout.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Controllers
{
    [Route(WebAPI.Order)]
    [ApiController]
    public class OrderController : Controller
    {
        private JwtService _jwtService;

        public OrderController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }
        
        [HttpGet("get/{id}")]
        public IActionResult GetCart(int id)
        {
            return Ok();
        }
    }
}
