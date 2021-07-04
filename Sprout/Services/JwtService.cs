﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Services
{
	public sealed class JwtService
	{
		private string _secureKey = "secure key, my secure key";

		public string Generate(int id)
		{
			var symmetricSecureKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
			var credentials = new SigningCredentials(symmetricSecureKey, SecurityAlgorithms.HmacSha256Signature);
			var header = new JwtHeader(credentials);

			var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
			var securityToken = new JwtSecurityToken(header, payload);

			return new JwtSecurityTokenHandler().WriteToken(securityToken);
		}

		public JwtSecurityToken Verify(string jwt)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_secureKey);
			tokenHandler.ValidateToken(jwt,
				 new TokenValidationParameters
				 {
					 IssuerSigningKey = new SymmetricSecurityKey(key),
					 ValidateIssuerSigningKey = true,
					 ValidateIssuer = false,
					 ValidateAudience = false
				 },
				 out SecurityToken validateToken);

			return (JwtSecurityToken)validateToken;
		}
	}
}
