using Microsoft.AspNetCore.Mvc;
using TICKETBOX.Models;
using TICKETBOX.Models.Tables;

namespace PROJECT.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        public IActionResult HomeClient()
        {
            using (var db = new fastticketContext())
            {
                var movies = db.Movies.ToList();
                return View(movies);
            }
        }
    }
}