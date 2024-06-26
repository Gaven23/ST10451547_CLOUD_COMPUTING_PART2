﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;
using System.Collections.Generic;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
	public class CheckOutController : Controller
	{
		private readonly OrderService _orderService;

		public CheckOutController(OrderService orderService)
		{
			_orderService = orderService;
		}
		public IActionResult CheckOrders(string itemsJson)
		{
			if (string.IsNullOrEmpty(itemsJson))
			{
				// Handle case where itemsJson is null or empty
				return RedirectToAction(nameof(Index));
			}

			try
			{
				// Deserialize the JSON string into a list of LineItem objects
				var items = JsonConvert.DeserializeObject<List<LineItem>>(itemsJson);

				// Process the items (optional step)
				var processedItems = ProcessItems(items);

				int totalPrice = (int)processedItems.Sum(item => item.Price);

				int totalQuantity = (int)processedItems.Sum(item => item.Quantity);

				var finalData = new Order()
				{
					TotalPrice = totalPrice,
					TotalQuantity = totalQuantity,
				};

				// Return the processed items view
				return View(finalData);
			}
			catch (JsonException ex)
			{
				return RedirectToAction(nameof(Index));
			}
		}

		private List<LineItem> ProcessItems(List<LineItem> items)
		{
			foreach (var item in items)
			{
				// Example: Update properties, perform calculations, etc.
			}
			return items;
		}

        public async Task<IActionResult> AddOrder(Order itemsJson)
        {

			_orderService.AddOrdersAsync(itemsJson);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index(List<LineItem> items)
		{
			// Optionally, further process items or display them in the view
			return View(items);
		}
	}
}
