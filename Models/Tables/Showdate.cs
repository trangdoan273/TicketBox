using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Showdate
    {
        public Showdate()
        {
            Showtimes = new HashSet<Showtime>();
            Tickets = new HashSet<Ticket>();
        }

        public int ShowdateId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public DateOnly? Showdate1 { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Showtime> Showtimes { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
