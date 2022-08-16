using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Users.Dto
{
	public class UserDto
	{
	}

	public class UserRegisterDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string InviteCode { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserClass { get; set; }
	}

	public class UserLoginDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
