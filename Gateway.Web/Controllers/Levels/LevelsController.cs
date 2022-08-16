using Gateway.Core.Domains.Levels;
using Gateway.Core.Domains.Levels.Services;
using Gateway.Web.Controllers.Levels.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Levels
{
	[Route("api/[controller]")]
	[ApiController]
	public class LevelsController : ControllerBase
	{
		private readonly ILevelService _levelService;

		public LevelsController(ILevelService levelService)
		{
			_levelService = levelService;
		}

		[HttpPost]
		public async Task CreateLevel(LevelDto levelDto)
		{
			await _levelService.CreateLevel(new Level
			{
				Name = levelDto.Name,
				Description = levelDto.Description,
				CourseId = levelDto.CourseId,
				Tutorial = levelDto.Tutorial,
				Stars = levelDto.Stars,
				Answer = levelDto.Answer,
				Type = levelDto.Type,
			});
		}

		[HttpGet("byCourseId")]
		public async Task<List<Level>> GetLevelsByCourseId(int id)
		{
			return await _levelService.GetLevelsByCourseId(id);
		}
	
		[HttpGet("{id}")]
		public async Task<Level> GetLevelsById(int id)
		{
			return await _levelService.GetLevelById(id);
		}

		[HttpDelete("{id}")]
		public async Task DeleteLevelById(int id)
		{
			await _levelService.DeleteLevelById(id);
		}

		[HttpPut("update")]
		public async Task UpdateLevel(LevelDto levelDto)
		{
			await _levelService.UpdateLevel(new Level
			{
				Id = levelDto.Id,
				Name = levelDto.Name,
				Description = levelDto.Description,
				CourseId = levelDto.CourseId,
				Tutorial = levelDto.Tutorial,
				Stars = levelDto.Stars,
				Answer = levelDto.Answer,
				Type = levelDto.Type,
			});
		}
	}
}

