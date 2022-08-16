using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Users.Services
{
	public interface IUserService
	{
		Task CreateUserAsync(User user);
		Task CreateTeacherAsync(User user);
		Task<UserLogin> LoginUserAsync(string email, string password);
		Task<User> GetUserInfoAsync(string id);
		Task<List<User>> GetAllUsersAsync();
		Task<List<User>> GetUsersByName(string name);
		Task<List<User>> GetUsersByUserClass(string name);
		Task ActivateUserAsync(string email);
		string GetCryptedPassword(string password);
	}
}
