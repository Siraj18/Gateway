using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core
{
	public interface IMailSender
	{
		Task SendMailAsync(string email, string message);
	}
}
