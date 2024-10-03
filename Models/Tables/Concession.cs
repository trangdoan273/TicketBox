using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Concession
    {
        public Concession()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ConcessionId { get; set; }
        public string ConcessionName { get; set; } = null!;
        public int? ConcessionPrice { get; set; }
        public string? ConcessionImage { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
