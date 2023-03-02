namespace Middleware.CustomMiddleware {

	public class MyCustomConventionalMiddleware {
		private readonly RequestDelegate _next;

		public MyCustomConventionalMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task Invoke(HttpContext context) {
			// Perform logic before the request is processed
			Console.WriteLine("CustomMiddleware: Before request");

			await _next(context);

			// Perform logic after the request is processed
			Console.WriteLine("CustomMiddleware: After request");
		}
	}

	public static class MyCustomConventionalMiddlewareExtention {
		public static IApplicationBuilder UseCustomConventionalMiddleware(this IApplicationBuilder builder) {
			return builder.UseMiddleware<MyCustomConventionalMiddleware>();
		}
	}
}