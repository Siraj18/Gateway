using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Controllers.Levels.Dto
{
	public class LevelDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tutorial { get; set; }
		public int CourseId { get; set; }
		public int Stars { get; set; }
		public string Type { get; set; }
		public string Answer { get; set; }
	}
}
