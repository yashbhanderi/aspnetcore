namespace Logging {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			builder.Host.ConfigureLogging(logging => {
				logging.ClearProviders();
				logging.AddConsole();
				logging.AddDebug();
				logging.AddEventLog();
			});

			builder.Services.AddHttpLogging(options => {
				options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
			});

			var app = builder.Build();

			app.UseHttpLogging();

			app.MapGet("/", () => "Hello World!");

			app.Run();
		}
	}
}