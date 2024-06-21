using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class OrderController : Controller
    {
		private readonly OrderService _checkOutService;

		public OrderController(OrderService _orderService)
		{
			_orderService = _orderService;
		}
		public IActionResult Index()
        {
            return View();
        }

		public IActionResult AddOrder(string itemsJson)
		{
			var items = JsonConvert.DeserializeObject<List<LineItem>>(itemsJson);

			if (string.IsNullOrEmpty(itemsJson))
			{
				// Handle case where itemsJson is null or empty
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
	}
}
