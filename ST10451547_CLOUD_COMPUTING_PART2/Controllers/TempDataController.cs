using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Controllers
{
    public class TempDataController : Controller
    {
        [HttpPost("StoreItems")]
        public IActionResult StoreItems([FromBody] List<LineItem> items)
        {
            TempData["CartItems"] = JsonConvert.SerializeObject(items);
            return Ok();
        }
    }
}
