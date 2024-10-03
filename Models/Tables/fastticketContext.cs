using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TICKETBOX.Models.Tables
{
    public partial class fastticketContext : DbContext
    {
        public fastticketContext()
        {
        }

        public fastticketContext(DbContextOptions<fastticketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Concession> Concessions { get; set; } = null!;
        public virtual DbSet<Info> Infos { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<Showdate> Showdates { get; set; } = null!;
        public virtual DbSet<Showtime> Showtimes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=fastticket;user=root;password=trang273@;allow user variables=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("cinema");

                entity.Property(e => e.CinemaId).HasColumnName("cinemaID");

                entity.Property(e => e.CinemaAddress)
                    .HasMaxLength(255)
                    .HasColumnName("cinemaAddress");

                entity.Property(e => e.CinemaEmail)
                    .HasMaxLength(100)
                    .HasColumnName("cinemaEmail");

                entity.Property(e => e.CinemaImage)
                    .HasColumnType("text")
                    .HasColumnName("cinemaImage");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(50)
                    .HasColumnName("cinemaName");

                entity.Property(e => e.CinemaPhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("cinemaPhoneNumber");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.RoomTotal).HasColumnName("roomTotal");

                entity.Property(e => e.ScreeningType)
                    .HasMaxLength(5)
                    .HasColumnName("screeningType");

                entity.Property(e => e.SeatTotal).HasColumnName("seatTotal");
            });

            modelBuilder.Entity<Concession>(entity =>
            {
                entity.ToTable("concession");

                entity.Property(e => e.ConcessionId).HasColumnName("concessionID");

                entity.Property(e => e.ConcessionImage)
                    .HasColumnType("text")
                    .HasColumnName("concessionImage");

                entity.Property(e => e.ConcessionName)
                    .HasMaxLength(100)
                    .HasColumnName("concessionName");

                entity.Property(e => e.ConcessionPrice).HasColumnName("concessionPrice");
            });

            modelBuilder.Entity<Info>(entity =>
            {
                entity.ToTable("info");

                entity.Property(e => e.InfoId).HasColumnName("infoID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InfoContent)
                    .HasColumnType("text")
                    .HasColumnName("infoContent");

                entity.Property(e => e.InfoImage)
                    .HasColumnType("text")
                    .HasColumnName("infoImage");

                entity.Property(e => e.InfoTitle)
                    .HasMaxLength(255)
                    .HasColumnName("infoTitle");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.Actor)
                    .HasMaxLength(100)
                    .HasColumnName("actor");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Director)
                    .HasMaxLength(100)
                    .HasColumnName("director");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .HasColumnName("duration");

                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .HasColumnName("genre");

                entity.Property(e => e.Label)
                    .HasMaxLength(5)
                    .HasColumnName("label");

                entity.Property(e => e.MovieFormat)
                    .HasMaxLength(5)
                    .HasColumnName("movieFormat");

                entity.Property(e => e.MovieImage)
                    .HasColumnType("text")
                    .HasColumnName("movieImage");

                entity.Property(e => e.MovieLanguage)
                    .HasMaxLength(50)
                    .HasColumnName("movieLanguage");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(255)
                    .HasColumnName("movieName");

                entity.Property(e => e.MoviePoster)
                    .HasColumnType("text")
                    .HasColumnName("moviePoster");

                entity.Property(e => e.ReleaseDate).HasColumnName("releaseDate");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.HasIndex(e => e.TicketId, "payment_ticket_idx");

                entity.HasIndex(e => e.UserId, "payment_user_idx");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.PaymentAmount).HasColumnName("paymentAmount");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_ticket");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_user");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("price");

                entity.HasIndex(e => e.SeatId, "price_seat_idx");

                entity.Property(e => e.PriceId).HasColumnName("priceID");

                entity.Property(e => e.PriceTicket).HasColumnName("priceTicket");

                entity.Property(e => e.SeatId).HasColumnName("seatID");

                entity.Property(e => e.Surcharge).HasColumnName("surcharge");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("price_seat");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.HasIndex(e => e.CinemaId, "room_cinema_idx");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.CinemaId).HasColumnName("cinemaID");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(100)
                    .HasColumnName("roomName");

                entity.Property(e => e.SeatCount).HasColumnName("seatCount");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CinemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_cinema");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("seat");

                entity.HasIndex(e => e.RoomId, "seat_room_idx");

                entity.Property(e => e.SeatId).HasColumnName("seatID");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.SeatNumb)
                    .HasMaxLength(5)
                    .HasColumnName("seatNumb");

                entity.Property(e => e.SeatStatus)
                    .HasColumnType("enum('Available','Booked')")
                    .HasColumnName("seatStatus");

                entity.Property(e => e.SeatType)
                    .HasColumnType("enum('Regular','VIP','Sweetbox')")
                    .HasColumnName("seatType");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_room");
            });

            modelBuilder.Entity<Showdate>(entity =>
            {
                entity.ToTable("showdate");

                entity.HasIndex(e => e.MovieId, "showdate_movie_idx");

                entity.HasIndex(e => e.RoomId, "showdate_room_idx");

                entity.Property(e => e.ShowdateId).HasColumnName("showdateID");

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.Showdate1).HasColumnName("showdate");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Showdates)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("showdate_movie");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Showdates)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("showdate_room");
            });

            modelBuilder.Entity<Showtime>(entity =>
            {
                entity.ToTable("showtime");

                entity.HasIndex(e => e.ShowdateId, "showtime_showdate_idx");

                entity.Property(e => e.ShowtimeId).HasColumnName("showtimeID");

                entity.Property(e => e.EndTime)
                    .HasColumnType("time")
                    .HasColumnName("endTime");

                entity.Property(e => e.ShowdateId).HasColumnName("showdateID");

                entity.Property(e => e.StartTime)
                    .HasColumnType("time")
                    .HasColumnName("startTime");

                entity.HasOne(d => d.Showdate)
                    .WithMany(p => p.Showtimes)
                    .HasForeignKey(d => d.ShowdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("showtime_showdate");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.HasIndex(e => e.ShowtimeId, "ticke_showtime_idx");

                entity.HasIndex(e => e.ConcessionId, "ticket_concession_idx");

                entity.HasIndex(e => e.PriceId, "ticket_price_idx");

                entity.HasIndex(e => e.ShowdateId, "ticket_showdate_idx");

                entity.HasIndex(e => e.UserId, "ticket_user_idx");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bookingDate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ConcessionId).HasColumnName("concessionID");

                entity.Property(e => e.PriceId).HasColumnName("priceID");

                entity.Property(e => e.ShowdateId).HasColumnName("showdateID");

                entity.Property(e => e.ShowtimeId).HasColumnName("showtimeID");

                entity.Property(e => e.TicketStatus)
                    .HasColumnType("enum('Booked','Used')")
                    .HasColumnName("ticketStatus");

                entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Concession)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ConcessionId)
                    .HasConstraintName("ticket_concession");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_price");

                entity.HasOne(d => d.Showdate)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ShowdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_showdate");

                entity.HasOne(d => d.Showtime)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ShowtimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_showtime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ticket_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserEmail, "userEmail")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .HasColumnName("sex");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateAt")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(255)
                    .HasColumnName("userAddress");

                entity.Property(e => e.UserEmail).HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("userPhoneNumber");

                entity.Property(e => e.UserRole)
                    .HasColumnType("enum('User','Admin')")
                    .HasColumnName("userRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
