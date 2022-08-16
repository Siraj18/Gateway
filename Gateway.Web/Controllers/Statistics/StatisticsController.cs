using Gateway.Core.Domains.Courses;
using Gateway.Core.Domains.Statistics;
using Gateway.Core.Domains.Statistics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Statistics
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticService _statisticService;

		public StatisticsController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		[HttpGet("{userId}")]
		public async Task<Statistic> GetStatisticByUserId(string userId)
		{
			return await _statisticService.GetStatisticByUserId(userId);
		}

		[HttpGet("incCourse/{userId}")]
		public async Task IncrementCourseByUserId(string userId)
		{
			await _statisticService.IncrementCourseByUserId(userId);
		}

		[HttpGet("completeCourse")]
		public async Task CompleteCourse(string userId, int courseId)
		{

			await _statisticService.CompleteCourse(userId, courseId);
		}

		[HttpGet("completeLevel")]
		public async Task CompleteLevel(string userId, int courseId)
		{

			await _statisticService.CompleteLevel(userId, courseId);
		}

		[HttpGet("allCompleteCourses")]
		public async Task<List<Course>> GetCompletedCourses(string userId)
		{
			return await _statisticService.GetCompletedCourses(userId);
		}
	}
}
