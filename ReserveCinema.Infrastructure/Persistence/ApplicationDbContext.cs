using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options) { }

    public DbSet<Show> Shows => Set<Show>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<ReservationSeat> ReservationSeats => Set<ReservationSeat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Show>()
            .HasMany(s => s.Seats)
            .WithOne(s => s.Show)
            .HasForeignKey(s => s.ShowId);

        modelBuilder.Entity<Show>()
            .HasMany(s => s.Reservations)
            .WithOne(r => r.Show)
            .HasForeignKey(r => r.ShowId);

        modelBuilder.Entity<ReservationSeat>()
            .HasKey(rs => new { rs.ReservationId, rs.SeatId });

        modelBuilder.Entity<ReservationSeat>()
            .HasOne(rs => rs.Reservation)
            .WithMany(r => r.ReservationSeats)
            .HasForeignKey(rs => rs.ReservationId);

        modelBuilder.Entity<ReservationSeat>()
            .HasOne(rs => rs.Seat)
            .WithMany(s => s.ReservationSeats)
            .HasForeignKey(rs => rs.SeatId);
    }
}
