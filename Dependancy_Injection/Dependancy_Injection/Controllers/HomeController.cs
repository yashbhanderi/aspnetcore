using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Dependancy_Injection.Controllers {
	public class HomeController : Controller {

		private readonly ICitiesService _citiesService1;
		private readonly ICitiesService _citiesService2;
		private readonly ICitiesService _citiesService3;
		private readonly IServiceScopeFactory _serviceScopeFactory;

		// ******************* Constructor Injection
		public HomeController(ICitiesService service1, ICitiesService service2, ICitiesService service3, IServiceScopeFactory serviceScopeFactory) {         // Here object is injected automatically | No need to pass or call method

			//_citiesService = new CitiesService(); <- NEW keyword is villian
			_citiesService1 = service1;
			_citiesService2 = service2;
			_citiesService3 = service3;
			_serviceScopeFactory = serviceScopeFactory;
		}

		[Route("/")]
		public IActionResult Index() {
			List<string> cities = _citiesService1.GetCities();
			ViewBag.InstanceId1 = _citiesService1.InstanceID;
			ViewBag.InstanceId2 = _citiesService2.InstanceID;
			ViewBag.InstanceId3 = _citiesService3.InstanceID;

			//    ServiceScopeFactory.CreateScope()  <-------- To create CHILD SCOPE ***************
			using (IServiceScope scope = _serviceScopeFactory.CreateScope()) {

				// Now --> To Inject CitiesService Service OBJECT *********
				ICitiesService _citiesService4 = scope.ServiceProvider.GetRequiredService<ICitiesService>();     // This is EQUIVALENT TO INJECTING citiesService into CONSTRUCTOR

				ViewBag.ChildInstanceId = _citiesService4.InstanceID;

				// Database work	

			} // End of Scope  :::  Disposable method called AUTOMATICALLY !!!


			return View(cities);
		}


		// ***************** Method Injection

		//public IActionResult Index([FromServices] ICitiesService _citiesService) {
		//	List<string> cities = _citiesService.GetCities();
		//	return View(cities);
		//}
	}
}
