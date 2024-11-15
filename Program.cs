using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Project_Book_Shop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// C?u hình chu?i k?t n?i c? s? d? li?u
string connecting_string = "Server=DESKTOP-AHDNE2G\\SQLEXPRESS;Database=book_shop;User Id=sa;Password=123456@A; TrustServerCertificate=True";
builder.Services.AddDbContext<Db_context>(options => options.UseSqlServer(connecting_string));

// C?u hình Authentication s? d?ng Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";  // ???ng d?n ??ng nh?p
        options.LogoutPath = "/login/logout";  // ???ng d?n ??ng xu?t
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// S? d?ng xác th?c và phân quy?n
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
