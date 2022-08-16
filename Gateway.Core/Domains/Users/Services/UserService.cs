using Gateway.Core.Domains.Users.Repositories;
using Gateway.Core.Exceptions;
using Gateway.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Users.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMailSender _mailSender;

		public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMailSender mailSender)
		{
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_mailSender = mailSender;
		}

		public async Task ActivateUserAsync(string email)
		{
			await _userRepository.ActivateUserAsync(email);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task CreateTeacherAsync(User user)
		{

			var exists = await _userRepository.CheckEmailExistsAsync(user.Email);

			if (exists)
			{
				throw new ValidationException("Пользователь с таким email уже существует");
			}

			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
			user.Role = Roles.Teacher;
			user.IsActive = true;

			await _userRepository.CreateUserAsync(user);

			await _unitOfWork.SaveChangesAsync();
		}

		public async Task CreateUserAsync(User user)
		{
			var exists = await _userRepository.CheckEmailExistsAsync(user.Email);

			if (exists)
			{
				throw new ValidationException("Пользователь с таким email уже существует");
			}

			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
			user.Role = Roles.Student;
			user.IsActive = false;

			await _userRepository.CreateUserAsync(user);

			await _unitOfWork.SaveChangesAsync();

			//TODO cюда писать из CONFIGURATION
			//TODO также сделать проверку на is_active
			await _mailSender.SendMailAsync(user.Email, "http://localhost:14924/api/Email/" + user.Email);
		}

		public Task<List<User>> GetAllUsersAsync()
		{
			return _userRepository.GetAllUsersAsync();
		}

		public string GetCryptedPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		public async Task<User> GetUserInfoAsync(string id)
		{

			var user = await _userRepository.GetUserFromIdAsync(id);

			if (user == null)
			{
				throw new ObjectNotFoundException();
			}

			return user;
		}

		public async Task<List<User>> GetUsersByName(string name)
		{
			var users = await _userRepository.GetAllUsersAsync();

			if (String.IsNullOrEmpty(name))
			{
				throw new ValidationException("Пустое значение при поиске");
			}

			var filterUsers = users.Where(u =>
					(u.FirstName + u.LastName).ToLower().Contains(name.Trim().ToLower())
			).ToList();

			return filterUsers;
		}

		public async Task<List<User>> GetUsersByUserClass(string userClass)
		{
			var users = await _userRepository.GetAllUsersAsync();

			if (String.IsNullOrEmpty(userClass))
			{
				throw new ValidationException("Пустое значение при поиске");
			}

			var filterUsers = users.Where(u =>
			{
				if (u.UserClass == null)
				{
					return false;
				}

				return u.UserClass.ToLower().Contains(userClass.Trim().ToLower());
			}
			).ToList();

			return filterUsers;
		}

		public async Task<UserLogin> LoginUserAsync(string email, string password)
		{
			var identity = await GetIdentityAsync(email, password);

			if (identity == null)
			{
				throw new ValidationException("Неверный email или пароль");
			}

			var token = JwtToken.CreateToken(identity);

			return new UserLogin
			{
				Token = token,
				Id = identity.Claims.ToList()[0].Value,
			};
		}

		private async Task<ClaimsIdentity> GetIdentityAsync(string email, string password)
		{
			var user = await _userRepository.GetUserFromEmailAsync(email);


			if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
			{
				return null;
			}

			if (!user.IsActive)
			{
				throw new ValidationException("Электронная почта не активирована");
			}

			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
			};

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			return claimsIdentity;
		}
	}
}
