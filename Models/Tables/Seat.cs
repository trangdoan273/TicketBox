using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Seat
    {
        public Seat()
        {
            Prices = new HashSet<Price>();
        }

        public int SeatId { get; set; }
        public int RoomId { get; set; }
        public string? SeatNumb { get; set; }
        public string? SeatType { get; set; }
        public string? SeatStatus { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Price> Prices { get; set; }
    }
}
