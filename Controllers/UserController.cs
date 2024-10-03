using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TICKETBOX.Models.Tables;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace TICKETBOX.UserController
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult UserProfile()
        {
            var userID = User.Identity.Name; 

           
            using (var db = new fastticketContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == userID); 

                
                if (user == null || user.UserRole == "Admin")
                {
                    return RedirectToAction("Management", "Admin");
                }

                return View(user); 
            }
        }

        public IActionResult UserDetailProfile(){
            return View();
        }
    }
}
