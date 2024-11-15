using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
	[Route("checkout")]
	public class CheckoutController : Controller
	{
		[HttpGet("")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
