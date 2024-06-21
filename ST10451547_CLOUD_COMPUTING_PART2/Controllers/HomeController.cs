using Microsoft.AspNetCore.Mvc;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;
using ST10451547_CLOUD_COMPUTING_PART2.Models;
using System.Diagnostics;
using System.Threading;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductService _productService;


        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreatOrder(LineItem lineItem)
        {
            if (ModelState.IsValid)
            {
                if (lineItem is null)
                    return BadRequest("A lineItem must be present");

                await _productService.AddLineItem(lineItem);

                return RedirectToAction(nameof(Cart));
            }

            return View(lineItem);
        }


        public async Task<IActionResult> Cart(CancellationToken cancellationToken)
        {
            var products = await _productService.GetLineItemAsync(cancellationToken);

            return View(products.ToList());
        }

        [HttpPost]
        public IActionResult UpdateCart(IEnumerable<LineItem> items)
        {
            // Process the line items
            foreach (var item in items)
            {
                // Process each item
            }

            // Redirect to a different action or return a view
            return RedirectToAction("Checkout");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
