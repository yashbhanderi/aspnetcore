using Microsoft.AspNetCore.Mvc;

namespace dependency_injection.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderCalculator _orderCalculator;
        private readonly IOrderConfirmationService _confirmationService;

        public OrderCalculator(IOrderCalculator orderCalculator, IOrderConfirmationService confirmationService)
        {
            _orderCalculator = orderCalculator;
            _confirmationService = confirmationService;
        }

        public IActionResult Index()
        {
            return View();  
        }
    }
}
