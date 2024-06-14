using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Abstraction;
using WebAppGeek.Dto;
using WebAppGeek.Models;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("download_csv")]
        public IActionResult DownloadCsvFile()
        {
            var products = _productRepository.GetAllProducts();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name,Price,Description,ProductGroupId");

            foreach (var product in products)
            {
                sb.AppendLine($"{product.Name},{product.Price},{product.Description},{product.ProductGroupId}");
            }

            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", "products.csv");
        }
    }
}