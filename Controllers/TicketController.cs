using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TICKETBOX.Models.Tables;
using TICKETBOX.Models;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using ZstdSharp.Unsafe;



namespace PROJECT.Models
{
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        public IActionResult SelectShowtimes(int id)
        {
            using (var db = new fastticketContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.MovieId == id);
                var showDates = db.Showdates.Where(sd => sd.MovieId == id).Take(7).ToList();

                ViewBag.SelectShowtimesInfo = new SelectShowtimesViewModel()
                {
                    Id = movie.MovieId,
                    MovieName = movie.MovieName,
                    Content = movie.Content,
                    Actor = movie.Actor,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    ReleaseDate = movie.ReleaseDate.ToString(),
                    Duration = movie.Duration,
                    MovieImage = movie.MovieImage,
                    ShowDates = showDates.Select(sd => sd.Showdate1.ToString()).ToList(),
                };
                return View();
            }

        }

        public IActionResult SelectSeat(int id)
        {
            using (var db = new fastticketContext())
            {
                var showtimes = db.Showtimes.FirstOrDefault(st => st.ShowtimeId == id);
                ViewBag.SelectSeatInfo = new SelectSeatModel()
                {
                    Id = showtimes.ShowtimeId,
                };
                return View();
            }

        }
        public IActionResult SelectConcession()
        {
            return View();
        }

        public IActionResult Ticket(int id)
        {
            using (var db = new fastticketContext())
            {
                var ticket = db.Tickets.FirstOrDefault(t => t.TicketId == id);
                var showDate = db.Showdates.FirstOrDefault(t => t.ShowdateId == ticket.ShowdateId);
                var showTime = db.Showtimes.FirstOrDefault(t => t.ShowtimeId == ticket.ShowtimeId);
                var movie = db.Movies.FirstOrDefault(sd => sd.MovieId == showDate.MovieId);
                var room = db.Rooms.FirstOrDefault(sd => sd.RoomId == showDate.RoomId);
                var cinema = db.Cinemas.FirstOrDefault(r => r.CinemaId == room.CinemaId);
                var price = db.Prices.FirstOrDefault(t => t.PriceId == ticket.PriceId);
                var seat = db.Seats.FirstOrDefault(p => p.SeatId == price.SeatId);
                var concession = db.Concessions.FirstOrDefault(t => t.ConcessionId == ticket.ConcessionId);

                ViewBag.TicketInfo = new TicketInfoModel()
                {
                    Id = ticket.TicketId,
                    MovieName = movie.MovieName,
                    ShowDates = showDate.Showdate1.ToString(),
                    Duration = $"{showTime.StartTime} - {showTime.EndTime}",
                    CinemaName = cinema.CinemaName,
                    SeatName = seat.SeatNumb,
                    RoomName = room.RoomName,
                    ConcessionName = concession.ConcessionName,
                    TotalPrice = ticket.TotalAmount.ToString(),
                    MovieImage = movie.MovieImage
                };
                return View();
            }
        }
    }
}