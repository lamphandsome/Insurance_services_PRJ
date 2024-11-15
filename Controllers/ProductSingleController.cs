using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
	[Route("product-single")]
	public class Product_Single : Controller
	{
        private readonly Db_context _context;
        public Product_Single(Db_context context)
        {
            _context = context;
        }
        [HttpGet("")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
