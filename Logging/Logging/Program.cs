using Serilog;

namespace Logging {
	public class Program {
		public static void Main(string[] args) {
			Log.Logger = new LoggerConfiguration()
								.WriteTo.File("log.txt")
								//.WriteTo.Console()
								.CreateLogger();

			try {
				Log.Warning("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

				var builder = WebApplication.CreateBuilder(args);

				builder.Host.UseSerilog(); // <-- Add this line

				var app = builder.Build();

				app.MapGet("/", () => "Hello World!");

				app.Run();
			}
			catch (Exception ex) {
				Log.Fatal(ex, "Application terminated unexpectedly");
			}
			finally {
				Log.CloseAndFlush();
			}
		}
	}
}