using Gateway.Core.Domains.Courses.Repositories;
using Gateway.Core.Domains.Statistics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Courses.Services
{
	public class CourseService : ICourseService
	{
		private readonly ICoursesRepository _coursesRepository;
		private readonly IUnitOfWork _unitOfWork;

		public CourseService(ICoursesRepository coursesRepository, IUnitOfWork unitOfWork, IStatisticsRepository statisticsRepository)
		{
			_coursesRepository = coursesRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task CreateCourse(Course course)
		{
			await _coursesRepository.CreateCourse(course);

			await _unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteCourseById(int id)
		{
			await _coursesRepository.DeleteCourseById(id);

			await _unitOfWork.SaveChangesAsync();
		}

		public Task<List<Course>> GetCompletedCourses()
		{
			throw new NotImplementedException();
		}

		public Task<List<Course>> GetlAllCourses()
		{
			return _coursesRepository.GetlAllCourses();
		}

		public async Task<int> GetMaxCourseLevel(int statisticId, int courseId)
		{
			var result = await _coursesRepository.GetMaxCourseLevel(statisticId, courseId);

			await _unitOfWork.SaveChangesAsync();

			return result;
		}

		public async Task UpdateCourse(Course course)
		{
			await _coursesRepository.UpdateCourse(course);

			await _unitOfWork.SaveChangesAsync();
		}
	}
}
