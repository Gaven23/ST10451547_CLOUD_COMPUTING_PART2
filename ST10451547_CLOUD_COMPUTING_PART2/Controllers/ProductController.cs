using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;
using ST10451547_CLOUD_COMPUTING_PART2.SendEmailNotification;
using System.Threading;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly UserService _userService;
        public ProductController(ProductService productService, UserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                if (product is null)
                    return BadRequest("A product must be present");

                await _productService.AddProductAsync(product);

                return RedirectToAction(nameof(Index));
            }
    
            return View(product);
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _productService.GetProducts(cancellationToken);
          
            return View(products.ToList());
        }

        public async Task<IActionResult> Update(int? id, CancellationToken cancellationToken)
        {

            var product = new Product();
            if (id == null)
            {
                return NotFound();
            }
            
            var products = await _productService.GetProducts(cancellationToken);


            
            if (products != null)
            {
                product =  products.FirstOrDefault(e => e.ProductId == id);
            }

          
       
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product is null)
                    return BadRequest("A product must be present");

                await _productService.UpdateProductAsync(product);

                var client = _userService.GetUsersAsync().Result.ToList();
                
                EmailNotificationSystem.SendToAllUsers(client);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}
