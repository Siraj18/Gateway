using Gateway.Core.Domains.Users;
using Gateway.Core.Domains.Users.Services;
using Gateway.Web.Controllers.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Users
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("all")]
		public async Task<List<User>> GetAllUsers()
		{
			return await _userService.GetAllUsersAsync();
		}

		[HttpPost("register")]
		public async Task CreateUserAsync(UserRegisterDto registerDto)
		{ 
			await _userService.CreateUserAsync(new User
			{
				Email = registerDto.Email,
				Password = registerDto.Password,
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				InviteCode = registerDto.InviteCode,
				UserClass = registerDto.UserClass,
			});
		}

		// Тут потом сделать защиту роута с ролью админа
		[HttpPost("registerTeacher")]
		public async Task CreateTeacherAsync(UserRegisterDto registerDto)
		{
			await _userService.CreateTeacherAsync(new User
			{
				Email = registerDto.Email,
				Password = registerDto.Password,
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
			});
		}

		[HttpPost("login")]
		public async Task<UserLogin> LoginUserAsync(UserLoginDto loginDto)
		{
			return await _userService.LoginUserAsync(loginDto.Email, loginDto.Password);
		}

		[Authorize]
		[HttpGet("me")]
		public async Task<User> GetUserInfo()
		{
			var userId = User.Claims.ToList()[0].Value;

			return await _userService.GetUserInfoAsync(userId);
		}

		[HttpGet("getUserById/{id}")]
		public async Task<User> GetUserById(string id)
		{

			return await _userService.GetUserInfoAsync(id);
		}

		[HttpGet("getUsersByName/{name}")]
		public async Task<List<User>> GetUsersByName(string name)
		{
			return await _userService.GetUsersByName(name);
		}

		[HttpGet("getUsersByUserClass/{userClass}")]
		public async Task<List<User>> GetUsersByUserClass(string userClass)
		{
			return await _userService.GetUsersByUserClass(userClass);
		}

		[HttpGet("getPassword")]
		public string GetCryptedPassword(string password)
		{

			return _userService.GetCryptedPassword(password);
		}

	}
}
