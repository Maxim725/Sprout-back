using Microsoft.AspNetCore.Mvc.Filters;
using Sprout.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Filters
{
    public sealed class AuthFilter : Attribute,  IAsyncAuthorizationFilter
    {
        private readonly JwtService _jwtService;

        public AuthFilter(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            return new Task(() =>
            {

            });
        }
    }
}
