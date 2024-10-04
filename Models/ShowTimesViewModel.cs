
using TICKETBOX.Models.Tables;

namespace TICKETBOX.Models
{
    public partial class ShowtimesViewModel
    {
        public Movie Movie { get; set; }
        public List<Showdate> ShowDates { get; set; } = new List<Showdate>();
        public List<Showtime> ShowTimes { get; set; } = new List<Showtime>();
    }
}
