using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Users
{
	public class User
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string InviteCode { get; set; }
		public string UserClass { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public Roles Role { get; set; }
	}

	public class UserLogin
	{
		public string Token { get; set; }
		public string Id { get; set; }
	}

	public enum Roles
	{
		Admin,
		Student,
		Teacher
	}
}
