using Gateway.Core;
using Gateway.Core.Domains.Courses.Repositories;
using Gateway.Core.Domains.Levels.Repositories;
using Gateway.Core.Domains.Statistics.Repositories;
using Gateway.Core.Domains.Users.Repositories;
using Gateway.Data.Courses.Repositories;
using Gateway.Data.Levels.Repositories;
using Gateway.Data.Statistics.Repositories;
using Gateway.Data.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data
{
	public static class Bootstrap
	{
		public static IServiceCollection AddData(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICoursesRepository, CoursesRepository>();
			services.AddScoped<ILevelsRepository, LevelsRepository>();
			services.AddScoped<IStatisticsRepository, StatisticsRepository>();

			services.AddScoped<IUnitOfWork, EfUnitOfWork>();

			services.AddDbContext<GatewayContext>(options => options
				.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345")
				.UseSnakeCaseNamingConvention()
				);

			// docker run -p 5432:5432 --name some-postgres -e POSTGRES_PASSWORD=12345 -d postgres:12-alpine

			return services;
		}
	}
}
