using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Ticket
    {
        public Ticket()
        {
            Payments = new HashSet<Payment>();
        }

        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int ShowtimeId { get; set; }
        public int ShowdateId { get; set; }
        public int PriceId { get; set; }
        public int? ConcessionId { get; set; }
        public string? TicketStatus { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? TotalAmount { get; set; }

        public virtual Concession? Concession { get; set; }
        public virtual Price Price { get; set; } = null!;
        public virtual Showdate Showdate { get; set; } = null!;
        public virtual Showtime Showtime { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
