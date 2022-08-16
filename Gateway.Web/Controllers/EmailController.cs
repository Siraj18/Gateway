using Gateway.Core.Domains.Users.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IUserService _userService;

		public EmailController(IUserService userService)
		{
			_userService = userService;
		}


		[HttpGet("{email}")]
		public async Task<string> ActivateUser(string email)
		{
			await _userService.ActivateUserAsync(email);

			return "Успешно активировано";
		}
	}
}
