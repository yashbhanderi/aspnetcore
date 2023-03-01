using ServiceContracts;
using Services;

namespace Dependancy_Injection {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

			// Adding Services to -------> IoC Container (builder.Services <=> IServiceContainer) <---------------

			//builder.Services.Add(new ServiceDescriptor(
			//	typeof(ICitiesService), // Calling Interface
			//	typeof(CitiesService),  // Object Creation
			//	ServiceLifetime.Scoped  // Service Lifetime
			//	));

			// Short Version
			builder.Services.AddScoped<ICitiesService, CitiesService>();

			var app = builder.Build();

			app.UseStaticFiles();
			app.UseRouting();
			app.MapControllers();

			app.Run();
		}
	}
}