using Gateway.Core.Domains.Users;
using Gateway.Core.Domains.Users.Repositories;
using Gateway.Core.Exceptions;
using Gateway.Data.Statistics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Users.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly GatewayContext _gatewayContext;

		public UserRepository(GatewayContext gatewayContext)
		{
			_gatewayContext = gatewayContext;
		}

		public async Task ActivateUserAsync(string email)
		{
			var user = await _gatewayContext.Users.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				throw new ObjectNotFoundException();
			}

			if (user.IsActive)
			{
				throw new ValidationException("Пользователь уже активирован");
			}

			user.IsActive = true;
		}

		public async Task<bool> CheckEmailExistsAsync(string email)
		{
			var exists = await _gatewayContext.Users.AnyAsync(u => u.Email == email);

			return exists;
		}

		public async Task CreateUserAsync(User user)
		{
			var model = new UserDbModel
			{
				Id = Guid.NewGuid().ToString(),
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserClass = user.UserClass,
				Role = user.Role,
				CreatedDate = DateTime.Now,
				IsActive = user.IsActive,
			};

			await _gatewayContext.Users.AddAsync(model);

			var statistic = new StatisticDbModel
			{
				MaxCourse = 0,
				User = model,
			};

			await _gatewayContext.Statistics.AddAsync(statistic);
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			var users = await _gatewayContext.Users.AsNoTracking().ToListAsync();

			return users.Select(u => new User
			{
				Id = u.Id,
				Email = u.Email,
				Password = u.Password,
				FirstName = u.FirstName,
				LastName = u.LastName,
				UserClass = u.UserClass,
				Role = u.Role,
				CreatedDate = u.CreatedDate,
				IsActive = u.IsActive,
			}).ToList();

		}

		public async Task<User> GetUserFromEmailAsync(string email)
		{
			var user = await _gatewayContext.Users.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				return null;
			}

			return new User
			{
				Id = user.Id,
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserClass = user.UserClass,
				Role = user.Role,
				CreatedDate = user.CreatedDate,
				IsActive = user.IsActive,
			};
		}

		public async Task<User> GetUserFromIdAsync(string id)
		{
			var user = await _gatewayContext.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (user == null)
			{
				return null;
			}

			return new User
			{
				Id = user.Id,
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserClass = user.UserClass,
				Role = user.Role,
				CreatedDate = user.CreatedDate,
				IsActive = user.IsActive,
			};
		}
	}
}
