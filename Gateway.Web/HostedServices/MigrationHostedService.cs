using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gateway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Web.HostedServices
{
	public class MigrationHostedService : IHostedService
	{
		private readonly IServiceProvider _serviceProvider;

		public MigrationHostedService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				var context = scope.ServiceProvider.GetService<GatewayContext>();

				if (context == null)
				{
					throw new Exception($"{nameof(GatewayContext)} not registered");
				}

				context.Database.Migrate();
			}


			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
