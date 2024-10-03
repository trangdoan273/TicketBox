using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Showtime
    {
        public Showtime()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ShowtimeId { get; set; }
        public int ShowdateId { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public virtual Showdate Showdate { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
