using Middleware.CustomMiddleware;

namespace Middleware {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Adding Custom Middleware
			// 1) Add service | To Use Dependency Injection
			builder.Services.AddTransient<MyCustomMiddleware1>();
			builder.Services.AddTransient<MyCustomMiddleware2>();
			//builder.Services.AddScoped<MyCustomConventionalMiddleware>();

			var app = builder.Build();

			//app.UseMiddleware<MyCustomMiddleware1>();
			app.UseCustomMiddleware1();   // ************* Middleware Extension Method *************
			app.UseMiddleware<MyCustomMiddleware2>();
			app.UseCustomConventionalMiddleware();

			app.UseWhen(
				context => context.Request.Query.ContainsKey("username"),   // Condition
				  app => {
					  app.Use(async (context, next) => {
						  await context.Response.WriteAsync("UseWhen Example: In the When Pipeline\n");
						  await next();
					  });
				  }
				);  // It continuous with the main pipeline
			 
			app.Use(async (HttpContext context, RequestDelegate next) => {
				await context.Response.WriteAsync("Hello Middleware 1\n");
				await next(context);    // We can choose | wheather call or not
				await context.Response.WriteAsync("Hello Again Middleware 1\n");
			});


			app.Use(async (context, next) => {
				await context.Response.WriteAsync("Hello Middleware 2\n");
				await next(context);  // We have to call | No option | Bcz of asp.net core design
				await context.Response.WriteAsync("Hello Again Middleware 2\n");
			});


			app.Run(async (HttpContext context) => {
				await context.Response.WriteAsync("Hello Middleware 3\n ");
				await context.Response.WriteAsync("Hello Again Middleware 3\n");
			});

			app.Run();
		}
	}
}