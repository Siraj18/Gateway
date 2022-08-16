using Gateway.Data.Courses;
using Gateway.Data.Levels;
using Gateway.Data.Statistics;
using Gateway.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;


namespace Gateway.Data
{
	public class GatewayContext : DbContext
	{
		public DbSet<UserDbModel> Users { get; set; }
		public DbSet<CourseDbModel> Courses { get; set; }
		public DbSet<LevelDbModel> Levels { get; set; }
		public DbSet<StatisticDbModel> Statistics { get; set; }
		public DbSet<StatisticCourseDbModel> StatisticCourse { get; set; }

		public GatewayContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatewayContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine);
			base.OnConfiguring(optionsBuilder);
		}


		public class Factory : IDesignTimeDbContextFactory<GatewayContext>
		{
			public GatewayContext CreateDbContext(string[] args)
			{
				var options = new DbContextOptionsBuilder()
					.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345")
					.UseSnakeCaseNamingConvention()
					.Options;


				return new GatewayContext(options);
			}
		}
	}
}
