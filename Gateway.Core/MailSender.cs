using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Core
{
	public class MailSender : IMailSender
	{
		public async Task SendMailAsync(string email, string message)
		{
			MailAddress from = new MailAddress("siraj0518@yandex.ru", "LearnCode");
			MailAddress to = new MailAddress(email);
			MailMessage m = new MailMessage(from, to);
			m.Subject = "Активация учетной записи";
			m.Body = message;
			SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
			smtp.Credentials = new NetworkCredential("siraj0518@yandex.ru", "cofdcwjbrmogopsz");
			smtp.EnableSsl = true;
			await smtp.SendMailAsync(m);
		}
	}
}
