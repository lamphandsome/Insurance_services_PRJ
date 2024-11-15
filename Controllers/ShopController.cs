using Microsoft.AspNetCore.Mvc;
using Project_Book_Shop.Models;
using System.Linq;

namespace Project_Book_Shop.Controllers
{
    [Route("shop")]
    public class ShopController : Controller
    {
        private readonly Db_context _context;

        public ShopController(Db_context context)
        {
            _context = context;
        }

        // Trang danh sách sản phẩm
        [HttpGet("")]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Trang chi tiết sản phẩm
        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
