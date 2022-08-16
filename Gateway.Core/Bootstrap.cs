using Gateway.Core.Domains.Courses.Services;
using Gateway.Core.Domains.Levels.Services;
using Gateway.Core.Domains.Statistics.Services;
using Gateway.Core.Domains.Users.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core
{
	public static class Bootstrap
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			services.AddScoped<IMailSender, MailSender>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICourseService, CourseService>();
			services.AddScoped<ILevelService, LevelService>();
			services.AddScoped<IStatisticService, StatisticService>();

			return services;
		}
	}
}
