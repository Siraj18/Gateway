using Gateway.Core.Domains.Statistics;
using Gateway.Core.Domains.Users;
using Gateway.Data.Statistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data.Users
{
	public class UserDbModel
	{
		public string Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserClass { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public Roles Role { get; set; }
		public StatisticDbModel Statistic { get; set; }
	}
	internal class Map : IEntityTypeConfiguration<UserDbModel>
	{
		public void Configure(EntityTypeBuilder<UserDbModel> builder)
		{
			builder
				.Property(r => r.Role)
				.HasConversion<string>();

			builder
				.HasOne(u => u.Statistic)
				.WithOne(s => s.User)
				.HasForeignKey<StatisticDbModel>(s => s.UserId);


			builder.ToTable("users");
		}
	}
}
