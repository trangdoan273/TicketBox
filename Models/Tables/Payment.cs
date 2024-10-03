using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public int? PaymentAmount { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
