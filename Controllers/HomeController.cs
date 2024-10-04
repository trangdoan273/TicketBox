using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TICKETBOX.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TICKETBOX.Models.Tables;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;

namespace TICKETBOX.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public IActionResult Index()
    {
        using (var db = new fastticketContext())
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("HomeClient", "Client");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
