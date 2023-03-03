namespace Configurations_and_Options {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

			// :::  Inject Configuration as dependency :::
			builder.Services.Configure<ClientAPI>
				(builder.Configuration.GetSection("ClientAPI"));

			// ::: Custom Configurations File :::
			builder.Host.ConfigureAppConfiguration((hostingContext, config) => {
				config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
			});

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseRouting();


			// ::: Configuration used in Program.cs File :::

			//app.MapGet("/", async context => {
			//	await context.Response.WriteAsync(app.Configuration["MyKey"]);
			//	await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));     //GetValue<DataType>(key, defaultValueIFAny)
			//																						//await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10));
			//});

			app.MapControllers();

			app.Run();
		}
	}
}