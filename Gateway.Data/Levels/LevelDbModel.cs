using Gateway.Data.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Levels
{
	public class LevelDbModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tutorial { get; set; }
		public int CourseId { get; set; }
		public int Stars { get; set; }
		public int Counter { get; set; }
		public string Type { get; set; }
		public string Answer { get; set; }
		public Boolean IsLast { get; set; }
		public virtual CourseDbModel Course { get; set; }

	}

	internal class Map : IEntityTypeConfiguration<LevelDbModel>
	{
		public void Configure(EntityTypeBuilder<LevelDbModel> builder)
		{
			builder.ToTable("levels");

			builder.HasOne(l => l.Course)
				.WithMany(c => c.Levels)
				.HasForeignKey(l => l.CourseId);
		}
	}


}
