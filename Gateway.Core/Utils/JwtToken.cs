using Gateway.Core.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Utils
{
	public static class JwtToken
	{
		public static string CreateToken(ClaimsIdentity identity)
		{
			var now = DateTime.Now;

			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.Issuer,
					audience: AuthOptions.Audience,
					notBefore: now,
					claims: identity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
					signingCredentials: new SigningCredentials(
							AuthOptions.GetSymmetricSecurityKey(),
							SecurityAlgorithms.HmacSha256
					)
				);

			var token = new JwtSecurityTokenHandler().WriteToken(jwt);

			return token;
		}
	}
}
