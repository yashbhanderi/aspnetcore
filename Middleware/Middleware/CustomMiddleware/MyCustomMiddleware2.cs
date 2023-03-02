namespace Middleware.CustomMiddleware {
	public class MyCustomMiddleware2 : IMiddleware {
		public async Task InvokeAsync(HttpContext context, RequestDelegate next) {

			await context.Response.WriteAsync("Start of Custom Middleware: 2\n");
			await next(context);
			await context.Response.WriteAsync("End of Custom Middleware: 2\n");

		}
	}
}
