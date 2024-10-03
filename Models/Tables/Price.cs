using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Price
    {
        public Price()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int PriceId { get; set; }
        public int SeatId { get; set; }
        public int PriceTicket { get; set; }
        public int? Surcharge { get; set; }

        public virtual Seat Seat { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
