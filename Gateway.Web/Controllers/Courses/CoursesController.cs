using Gateway.Core.Domains.Courses;
using Gateway.Core.Domains.Courses.Services;
using Gateway.Web.Controllers.Courses.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Courses
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoursesController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public CoursesController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		[HttpPost]
		public async Task CreateCourse(CourseDto courseDto)
		{
			await _courseService.CreateCourse(new Course
			{
				Name = courseDto.Name,
				Description = courseDto.Description,
				Level = courseDto.Level,
				IsBonus = courseDto.IsBonus
			});
		}

		[HttpGet("all")]
		public async Task<List<Course>> GetAllCourses()
		{
			return await _courseService.GetlAllCourses();
		}

		[HttpDelete("{id}")]
		public async Task DeleteCourseById(int id)
		{
			await _courseService.DeleteCourseById(id);
		}

		[HttpPut("update")]
		public async Task UpdateCourse(CourseDto course)
		{
			await _courseService.UpdateCourse(new Course
			{
				Id = course.Id,
				Name = course.Name,
				Description = course.Description,
				Level = course.Level,
				IsBonus = course.IsBonus
			});
		}

		[HttpGet("maxLevel")]
		public async Task<int> GetCourseMaxLevel(int statisticId, int courseId)
		{
			return await _courseService.GetMaxCourseLevel(statisticId, courseId);
		}

	}
}
