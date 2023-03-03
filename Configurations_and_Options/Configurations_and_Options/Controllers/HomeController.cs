using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configurations_and_Options.Controllers {
	public class HomeController : Controller {

		private readonly IConfiguration _configuration;
		private readonly ClientAPI _options;

		public HomeController(IOptions<ClientAPI> options) {
			_options = options.Value;
		}

		[Route("/")]
		public IActionResult Index() {

			// ::: Single Key-value pair :::

			//ViewBag.MyKey = _configuration["MyKey"];
			//ViewBag.MyKey = _configuration.GetValue<string>("MyKey");


			// ::: Heirarchical Keys :::

			//ViewBag.MyChildKey = _configuration["ClientAPI:MyChildKey"];

			// ::: Section : Easy to Use when So much data in ONE JSON OBJECT :::

			//IConfigurationSection MyKeySection = _configuration.GetSection("ClientAPI");

			//ViewBag.ClientID = MyKeySection["ClientID"];
			//ViewBag.ClientName = MyKeySection["ClientName"];



			// ::: Options :::

			//ClientAPI? options = _configuration.GetSection("ClientAPI").Get<ClientAPI>();


			//ViewBag.ClientID = options.ClientID;
			//ViewBag.ClientName = options.ClientName;


			// ::: Configuration as a SERVICE :::

			ViewBag.ClientID = _options.ClientID;
			ViewBag.ClientName = _options.ClientName;


			return View();


		}
	}
}
