using Gateway.Core.Domains.Users;
using Gateway.Data.Courses;
using Gateway.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Statistics
{
	public class StatisticDbModel
	{
		public int Id { get; set; }
		public int MaxCourse { get; set; }
		public string UserId { get; set; }
		public UserDbModel User { get; set; }
		public List<CourseDbModel> Courses { get; set; } = new List<CourseDbModel>();
	}
	internal class Map : IEntityTypeConfiguration<StatisticDbModel>
	{
		public void Configure(EntityTypeBuilder<StatisticDbModel> builder)
		{
			builder.ToTable("statistics");

			
		}
	}
}
