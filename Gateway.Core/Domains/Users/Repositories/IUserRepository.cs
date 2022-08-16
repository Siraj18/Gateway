using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Users.Repositories
{
	public interface IUserRepository
	{
		Task CreateUserAsync(User user);
		Task<bool> CheckEmailExistsAsync(string email);
		Task<User> GetUserFromEmailAsync(string email);
		Task<User> GetUserFromIdAsync(string id);
		Task<List<User>> GetAllUsersAsync();
		Task ActivateUserAsync(string email);
	}
}
