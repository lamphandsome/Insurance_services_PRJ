using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
	[Route("about")]
	public class AboutController : Controller
	{
		[HttpGet("")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
