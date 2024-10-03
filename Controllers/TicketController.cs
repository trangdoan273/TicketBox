using Microsoft.AspNetCore.Mvc;
using PROJECT.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewData["Title"] = "Chọn Lịch Chiếu";
            return View();
        }
         public IActionResult SelectSeat(){
            ViewData["Title"] = "Chọn Ghế";
            return View();
         }
         public IActionResult SelectConcession(){
            ViewData["Title"] = "Chọn Bỏng Nước";
            return View();
         }
    }
}