using Microsoft.AspNetCore.Mvc;
using ST10451547_CLOUD_COMPUTING_PART2.BusinessLogic.Services;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Product product)
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

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
