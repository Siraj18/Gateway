using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Levels.Repositories
{
	public interface ILevelsRepository
	{
		Task CreateLevel(Level level);
		Task<List<Level>> GetLevelsByCourseId(int id);
		Task DeleteLevelById(int id);
		Task UpdateLevel(Level level);
		Task<Level> GetLevelById(int id);
	}
}
