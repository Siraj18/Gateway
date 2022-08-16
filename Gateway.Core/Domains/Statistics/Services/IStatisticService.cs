using Gateway.Core.Domains.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Statistics.Services
{
	public interface IStatisticService
	{
		Task<Statistic> GetStatisticByUserId(string userId);
		Task IncrementCourseByUserId(string userId);
		Task CompleteCourse(string userId, int courseId);
		Task CompleteLevel(string userId, int courseId);
		Task<List<Course>> GetCompletedCourses(string userId);
	}
}
