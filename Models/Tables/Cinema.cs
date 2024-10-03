using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Cinema
    {
        public Cinema()
        {
            Rooms = new HashSet<Room>();
        }

        public int CinemaId { get; set; }
        public string CinemaName { get; set; } = null!;
        public string? CinemaAddress { get; set; }
        public string? CinemaPhoneNumber { get; set; }
        public string? CinemaEmail { get; set; }
        public int? SeatTotal { get; set; }
        public int? RoomTotal { get; set; }
        public string? ScreeningType { get; set; }
        public string? CinemaImage { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
