using Gateway.Data.Levels;
using Gateway.Data.Statistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Courses
{
	public class StatisticCourseDbModel
	{
		public int Id { get; set; }
		public int StatisticId { get; set; }
		public int CourseId { get; set; }
		public int MaxLevel { get; set; }
	}
}
