using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
	[Route("wishlist")]
	public class WishlistController : Controller
	{
		[HttpGet("")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
