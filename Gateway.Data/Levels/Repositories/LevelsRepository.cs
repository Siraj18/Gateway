using Gateway.Core.Domains.Levels;
using Gateway.Core.Domains.Levels.Repositories;
using Gateway.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Levels.Repositories
{
	public class LevelsRepository : ILevelsRepository
	{
		private readonly GatewayContext _gatewayContext;

		public LevelsRepository(GatewayContext gatewayContext)
		{
			_gatewayContext = gatewayContext;
		}

		public async Task CreateLevel(Level level)
		{
			var levels = await _gatewayContext.Levels.Where(l => l.CourseId == level.CourseId).ToListAsync();

			int maxCount = 0;

			if (levels.Count > 0)
			{
				maxCount = levels.Max(l => l.Counter);
			}

			foreach (var l in levels)
			{
				l.IsLast = false;
			}

			await _gatewayContext.Levels.AddAsync(new LevelDbModel
			{
				Name = level.Name,
				Description = level.Description,
				Tutorial = level.Tutorial,
				CourseId = level.CourseId,
				Stars = level.Stars,
				Counter = maxCount + 1,
				IsLast = true,
				Type = level.Type,
				Answer = level.Answer,
			});
		}

		public async Task DeleteLevelById(int id)
		{
			var deleteLevel = await _gatewayContext.Levels.FirstOrDefaultAsync(c => c.Id == id);

			if (deleteLevel == null)
			{
				throw new ObjectNotFoundException();
			}

			_gatewayContext.Levels.Remove(deleteLevel);
		}

		public async Task<Level> GetLevelById(int id)
		{
			var level = await _gatewayContext.Levels.FirstOrDefaultAsync(l => l.Id == id);

			if (level == null)
			{
				throw new ObjectNotFoundException();
			}

			return new Level
			{
				Id = level.Id,
				Name = level.Name,
				Description = level.Description,
				Counter = level.Counter,
				CourseId = level.CourseId,
				IsLast = level.IsLast,
				Tutorial = level.Tutorial,
				Stars = level.Stars,
				Type = level.Type,
				Answer = level.Answer,
			};
		}

		public async Task<List<Level>> GetLevelsByCourseId(int id)
		{
			var levels = await _gatewayContext.Levels.Where(l => l.CourseId == id).ToListAsync();

			return levels.Select(level => new Level { 
				Id = level.Id,
				Name = level.Name,
				Tutorial = level.Tutorial,
				CourseId = level.CourseId,
				Description = level.Description,
				Stars = level.Stars,
				Counter = level.Counter,
				IsLast = level.IsLast,
				Type = level.Type,
				Answer = level.Answer,
			}).ToList();
		}

		public async Task UpdateLevel(Level level)
		{
			var findLevel = await _gatewayContext.Levels.FirstOrDefaultAsync(l => l.Id == level.Id);

			if (findLevel == null)
			{
				throw new ObjectNotFoundException();
			}

			findLevel.Name = level.Name;
			findLevel.Description = level.Description;
			findLevel.Tutorial = level.Tutorial;
			findLevel.Stars = level.Stars;
			findLevel.Answer = level.Answer;
			findLevel.Type = level.Type;
		}
	}
}
