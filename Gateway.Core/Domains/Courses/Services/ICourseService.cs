using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Courses.Services
{
	public interface ICourseService
	{
		Task CreateCourse(Course course);
		Task<List<Course>> GetlAllCourses();
		Task UpdateCourse(Course course);
		Task DeleteCourseById(int id);
		Task<int> GetMaxCourseLevel(int statisticId, int courseId);
		
	}
}
