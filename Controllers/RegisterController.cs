using Microsoft.AspNetCore.Mvc;
using Project_Book_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project_Book_Shop.Controllers
{
    [Route("/register")]
    public class RegisterController : Controller
    {
        private readonly Db_context _context;

        public RegisterController(Db_context context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(new RegisterModel());
        }

        [HttpPost("")]
        public async Task<IActionResult> Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra email có tồn tại trong hệ thống không
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already registered.");
                return View(model);
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Password and confirmation do not match.");
                return View(model);
            }

            // Tạo mới người dùng
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Password = model.Password, // Lưu password chưa mã hóa, cần cải thiện
                Role = "User", // Role mặc định, bạn có thể sửa theo nhu cầu
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Login"); // Redirect về trang đăng nhập sau khi đăng ký
        }
    }
}
