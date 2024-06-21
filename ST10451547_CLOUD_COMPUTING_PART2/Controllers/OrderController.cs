using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class OrderController : Controller
    {
		private readonly OrderService _orderService;

		public OrderController(OrderService orderService)
		{
			_orderService = orderService;
		}


        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _orderService.GetOrdersAsync(cancellationToken);

            return View(products.ToList());
        }

        public async Task<IActionResult> AddOrder(Order itemsJson)
		{

			var tes = itemsJson;
			// Process the items (optional step)
		
			return RedirectToAction(nameof(Index));
		}

		private List<Order> ProcessItems(List<Order> items)
		{
	
			return items;
		}
	}
}
