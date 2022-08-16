using Gateway.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Web.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (ObjectNotFoundException exception)
			{
				httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				await httpContext.Response.WriteAsJsonAsync(new { Error = "Object Not Found" });
			}
			catch (ValidationException exception)
			{
				httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				await httpContext.Response.WriteAsJsonAsync(new { Message = exception.Message });
			}
			catch (Exception exception)
			{
				httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await httpContext.Response.WriteAsJsonAsync(new { Error = "Внутренняя ошибка сервера" });
			}
		}
	}
}
