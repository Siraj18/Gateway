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
	public class CourseDbModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsBonus { get; set; }
		public int Level { get; set; }
		public virtual List<LevelDbModel> Levels { get; set; }
		public List<StatisticDbModel> Statistics { get; set; } = new List<StatisticDbModel>();
	}
	internal class Map : IEntityTypeConfiguration<CourseDbModel>
	{
		public void Configure(EntityTypeBuilder<CourseDbModel> builder)
		{
			
			builder.ToTable("courses");
		}
	}
}
