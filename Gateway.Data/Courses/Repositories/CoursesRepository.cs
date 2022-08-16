using Gateway.Core.Domains.Courses;
using Gateway.Core.Domains.Courses.Repositories;
using Gateway.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Courses.Repositories
{
	public class CoursesRepository : ICoursesRepository
	{
		private readonly GatewayContext _gatewayContext;

		public CoursesRepository(GatewayContext gatewayContext)
		{
			_gatewayContext = gatewayContext;
		}

		public Task<bool> CheckCourseExistsById(int id)
		{
			return _gatewayContext.Courses.AnyAsync(c => c.Id == id);
		}

		public async Task CreateCourse(Course course)
		{
			await _gatewayContext.Courses.AddAsync(new CourseDbModel
			{
				Name = course.Name,
				Description = course.Description,
				Level = course.Level,
				IsBonus = course.IsBonus
			});
		}

		public async Task DeleteCourseById(int id)
		{
			var deleteCourse = await _gatewayContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

			if (deleteCourse == null)
			{
				throw new ObjectNotFoundException();
			}

			_gatewayContext.Courses.Remove(deleteCourse);

		}

		public async Task<List<Course>> GetlAllCourses()
		{
			var courses = await _gatewayContext.Courses.AsNoTracking().ToListAsync();

			return courses.Select(c => new Course { 
				Id = c.Id,
				Name = c.Name,
				Description = c.Description,
				Level = c.Level,
				IsBonus = c.IsBonus
			}).ToList();
		}

		public async Task<int> GetMaxCourseLevel(int statisticId, int courseId)
		{
			var statisticCourse = await _gatewayContext.StatisticCourse.FirstOrDefaultAsync(s => s.StatisticId == statisticId && s.CourseId == courseId);

			if (statisticCourse == null)
			{
				var newStatistic = new StatisticCourseDbModel
				{
					CourseId = courseId,
					StatisticId = statisticId,
					MaxLevel = 0,
				};

				await _gatewayContext.StatisticCourse.AddAsync(newStatistic);

				return 0;
			}

			return statisticCourse.MaxLevel;
		}

		public async Task UpdateCourse(Course course)
		{
			var findCourse = await _gatewayContext.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);

			if (findCourse == null)
			{
				throw new ObjectNotFoundException();
			}

			findCourse.Name = course.Name;
			findCourse.Description = course.Description;
			findCourse.Level = course.Level;
			findCourse.IsBonus = course.IsBonus;
		}
	}
}
