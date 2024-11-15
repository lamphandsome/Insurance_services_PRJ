using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
    [Route("card")]
    public class CardController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
