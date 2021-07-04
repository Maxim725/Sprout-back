using Microsoft.AspNetCore.Mvc;
using Sprout.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Controllers
{
    [Route(WebAPI.Category)]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public IActionResult GetCategories()
        {
            return new JsonResult(_categoryService.Get());
        }


    }
}
