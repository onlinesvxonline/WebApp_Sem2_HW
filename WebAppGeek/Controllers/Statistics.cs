using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheStatisticsController : ControllerBase
    {
        [HttpGet("cache_statistics")]
        public IActionResult GetCacheStatistics()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "statistics.txt");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "text/plain", "statistics.txt");
        }
    }
}