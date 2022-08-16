using Gateway.Core.Domains.Courses.Repositories;
using Gateway.Core.Domains.Levels.Repositories;
using Gateway.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Levels.Services
{
	public class LevelService : ILevelService
	{
		private readonly ILevelsRepository _levelsRepository;
		private readonly ICoursesRepository _coursesRepository;
		private readonly IUnitOfWork _unitOfWork;

		public LevelService(ILevelsRepository levelsRepository, ICoursesRepository coursesRepository, IUnitOfWork unitOfWork)
		{
			_levelsRepository = levelsRepository;
			_coursesRepository = coursesRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task CreateLevel(Level level)
		{
			var exists = await _coursesRepository.CheckCourseExistsById(level.CourseId);

			if (!exists)
			{
				throw new ValidationException("Нет курса с таким id");
			}

			await _levelsRepository.CreateLevel(level);

			await _unitOfWork.SaveChangesAsync();
		}

		public async Task DeleteLevelById(int id)
		{
			await _levelsRepository.DeleteLevelById(id);

			await _unitOfWork.SaveChangesAsync();
		}

		public Task<Level> GetLevelById(int id)
		{
			return _levelsRepository.GetLevelById(id);
		}

		public Task<List<Level>> GetLevelsByCourseId(int id)
		{
			return _levelsRepository.GetLevelsByCourseId(id);
		}

		public async Task UpdateLevel(Level level)
		{
			await _levelsRepository.UpdateLevel(level);

			await _unitOfWork.SaveChangesAsync();
		}
	}
}
