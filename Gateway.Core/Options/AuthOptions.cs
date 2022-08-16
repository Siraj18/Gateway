using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Options
{
	public static class AuthOptions
	{
		public static string Issuer = "MyAuthServer"; // издатель токена
		public static string Audience = "MyAuthClient"; // потребитель токена
		const string Key = "mysupersecret_secretkey!123";   // ключ для шифрации
		public static int Lifetime = 50; // время жизни токена - 1 минута
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}
