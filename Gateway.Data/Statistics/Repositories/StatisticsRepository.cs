using Gateway.Core.Domains.Courses;
using Gateway.Core.Domains.Statistics;
using Gateway.Core.Domains.Statistics.Repositories;
using Gateway.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Statistics.Repositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly GatewayContext _gatewayContext;

		public StatisticsRepository(GatewayContext gatewayContext)
		{
			_gatewayContext = gatewayContext;
		}

		public async Task AddCourseToStatistic(string userId, int courseId)
		{
			var statistic = await _gatewayContext.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);

			if (statistic == null)
			{
				throw new ObjectNotFoundException();
			}

			var course = await _gatewayContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

			if (course == null)
			{
				throw new ObjectNotFoundException();
			}

			statistic.Courses.Add(course);
			
			if (statistic.MaxCourse >= 0 && statistic.MaxCourse != 2 )
			{
				statistic.MaxCourse++;
			}
		}

		public async Task CompleteLevel(string userId, int courseId)
		{
			var statistic = await _gatewayContext.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);

			if (statistic == null)
			{
				throw new ObjectNotFoundException();
			}

			var statisticCourse = await _gatewayContext.StatisticCourse.FirstOrDefaultAsync(s => s.StatisticId == statistic.Id
									&& s.CourseId == courseId
									);

			statisticCourse.MaxLevel++;
		}

		public async Task<List<Course>> GetCompletedCourses(string userId)
		{
			var statistic = await _gatewayContext.Statistics
				.Include(s => s.Courses)
				.FirstOrDefaultAsync(s => s.UserId == userId);


			if (statistic == null)
			{
				throw new ObjectNotFoundException();
			}

			return statistic.Courses.Select(c =>
				   new Course
				   {
					   Id = c.Id,
					   Name = c.Name,
					   Description = c.Description,
					   IsBonus = c.IsBonus,
					   Level = c.Level
				   }
				).ToList();

		}

		public async Task<Statistic> GetStatisticByUserId(string userId)
		{
			var statistic = await _gatewayContext.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);

			if (statistic == null)
			{
				throw new ObjectNotFoundException();
			}

			return new Statistic
			{
				Id = statistic.Id,
				MaxCourse = statistic.MaxCourse,
				UserId = statistic.UserId,
			};
		}

		public async Task IncrementCourseByUserId(string userId)
		{
			var statistic = await _gatewayContext.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);

			if (statistic == null)
			{
				throw new ObjectNotFoundException();
			}

			statistic.MaxCourse += 1;

		}
	}
}
