namespace Middleware.CustomMiddleware {
	public class MyCustomMiddleware1 : IMiddleware {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) {

			await context.Response.WriteAsync("Start of Custom Middleware: 1\n");
			await next(context);
			await context.Response.WriteAsync("End of Custom Middleware: 1\n");

		}

	}

	public static class MyCustomMiddlewareExtension {
		public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app) {
			return app.UseMiddleware<MyCustomMiddleware1>();
		}
	}
}
