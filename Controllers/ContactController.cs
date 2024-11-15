using Microsoft.AspNetCore.Mvc;

namespace Project_Book_Shop.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        [HttpGet("")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
