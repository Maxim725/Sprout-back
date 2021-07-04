using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sprout.DB;
using Sprout.Domain.Dtos;
using Sprout.Domain.DBEntity;
using Sprout.Services;
using Microsoft.AspNetCore.Http;

namespace Sprout.Controllers
{

    [Route(WebAPI.Auth)]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserReposritory _userRepository;
        private readonly JwtService _jwtService;

        public AuthController(IUserReposritory userReposritory, JwtService jwtService)
        {
            _userRepository = userReposritory;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto model)
        {
            try
            {
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    BirthDate = DateTime.Parse(model.BirthDate),
                    HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Cart = new Cart()
                };

                user = _userRepository.Create(user);
                return Created("success", user);
            }
            catch(FormatException e)
            {
                return BadRequest("Дата рождения не валидна");
            }
            catch(Exception _)
            {
                return BadRequest("Not created");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            var user = _userRepository.GetByEmail(model.Email);

            if (user == null)
                return BadRequest(new { message = "Почта введена неправильно" });

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
                return BadRequest(new { message = "Пароль введён неверно" });

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                // Два этих значения нужны, чтобы на приложение куки перекидывать
                SameSite = SameSiteMode.None,
                Secure = true,
                Expires = new DateTimeOffset(DateTime.Now.AddDays(1)),
            });

            return Ok(new UserDto(user));
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return Ok(new { message = "Logout success" });
        }

        [HttpPost("check")]
        public IActionResult Check()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _userRepository.GetById(userId);

                return Ok(new UserDto(user));
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        //[HttpGet("users")]
        //public IActionResult Users()
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];

        //        var token = _jwtService.Verify(jwt);

        //        int userId = int.Parse(token.Issuer);

        //        var user = _userRepository.GetById(userId);

        //        return Ok(user);
        //    }
        //    catch (Exception e)
        //    {
        //        return Unauthorized();
        //    }
        //}

    }
}
