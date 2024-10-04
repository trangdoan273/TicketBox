using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TICKETBOX.Models.Tables;
using TICKETBOX.Models;
using Org.BouncyCastle.Crypto.Agreement.Srp;


namespace PROJECT.Models
{
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }
        public IActionResult SelectShowtimes()
        {
            return View();
        }

        public IActionResult SelectSeat()
        {

            return View();
        }
        public IActionResult SelectConcession()
        {

            return View();
        }

        public IActionResult Ticket()
        {
            using (var db = new fastticketContext())
            {
                var ticket = db.Tickets.Include(t => t.Showtime)
                .ThenInclude(s => s.Showdate)
                .ThenInclude(sd => sd.Movie)
                .Include(t => t.Showtime.Showdate.Room)
                .ThenInclude(r => r.Cinema)
                .Include(t => t.Price)
                .ThenInclude(p => p.Seat)
                .Include(t => t.Concession)
                .ToList();
                return View(ticket);
            }
        }
    }
}