using Gateway.Core.Domains.Courses;
using Gateway.Core.Domains.Statistics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Statistics.Services
{
	public class StatisticService : IStatisticService
	{
		private readonly IStatisticsRepository _statisticsRepository;
		private readonly IUnitOfWork _unitOfWork;

		public StatisticService(IStatisticsRepository statisticsRepository, IUnitOfWork unitOfWork)
		{
			_statisticsRepository = statisticsRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task CompleteCourse(string userId, int courseId)
		{
			await _statisticsRepository.AddCourseToStatistic(userId, courseId);

			await _unitOfWork.SaveChangesAsync();
		}

		public async Task CompleteLevel(string userId, int courseId)
		{
			await _statisticsRepository.CompleteLevel(userId, courseId);

			await _unitOfWork.SaveChangesAsync();
		}

		public Task<List<Course>> GetCompletedCourses(string userId)
		{
			return _statisticsRepository.GetCompletedCourses(userId);
		}

		public Task<Statistic> GetStatisticByUserId(string userId)
		{
			return _statisticsRepository.GetStatisticByUserId(userId);
		}

		public async Task IncrementCourseByUserId(string userId)
		{
			await _statisticsRepository.IncrementCourseByUserId(userId);

			await _unitOfWork.SaveChangesAsync();
		}
	}
}
