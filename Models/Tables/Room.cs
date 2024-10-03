using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Room
    {
        public Room()
        {
            Seats = new HashSet<Seat>();
            Showdates = new HashSet<Showdate>();
        }

        public int RoomId { get; set; }
        public int CinemaId { get; set; }
        public string RoomName { get; set; } = null!;
        public int? SeatCount { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Showdate> Showdates { get; set; }
    }
}
