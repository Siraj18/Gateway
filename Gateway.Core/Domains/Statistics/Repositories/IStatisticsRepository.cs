using Gateway.Core.Domains.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Statistics.Repositories
{
	public interface IStatisticsRepository
	{
		Task<Statistic> GetStatisticByUserId(string userId);
		Task IncrementCourseByUserId(string userId);
		Task AddCourseToStatistic(string userId, int courseId);
		Task CompleteLevel(string userId, int courseId);
		Task<List<Course>> GetCompletedCourses(string userId);
	}
}
