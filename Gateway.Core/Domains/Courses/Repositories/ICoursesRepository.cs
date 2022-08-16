using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Courses.Repositories
{
	public interface ICoursesRepository
	{
		Task CreateCourse(Course course);
		Task<List<Course>> GetlAllCourses();
		Task<bool> CheckCourseExistsById(int id);
		Task UpdateCourse(Course course);
		Task DeleteCourseById(int id);
		Task<int> GetMaxCourseLevel(int statisticId, int courseId);
	}
}
