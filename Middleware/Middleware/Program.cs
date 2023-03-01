namespace Middleware {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			//app.MapGet("/", () => "Hello World!");
			app.Run(async (HttpContext context) => {
				await context.Response.WriteAsync("Hello Middleware");
			});

			app.Run();
		}
	}
}