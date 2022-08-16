using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core.Domains.Levels
{
	// Тут еще много чего добавить
	public class Level
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tutorial { get; set; }
		public int CourseId { get; set; }
		public int Stars { get; set; }
		public int Counter { get; set; }
		public Boolean IsLast { get; set; }
		public string Type { get; set; }
		public string Answer { get; set; }
	}
}
