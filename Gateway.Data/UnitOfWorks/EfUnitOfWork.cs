using Gateway.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Data
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly GatewayContext _context;
		public EfUnitOfWork(GatewayContext context)
		{
			_context = context;
		}
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
