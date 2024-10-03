using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class User
    {
        public User()
        {
            Payments = new HashSet<Payment>();
            Tickets = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? Fullname { get; set; }
        public string? UserPhoneNumber { get; set; }
        public DateOnly? DoB { get; set; }
        public string? Sex { get; set; }
        public string? UserAddress { get; set; }
        public string? UserRole { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
