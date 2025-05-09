using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;
using ReserveCinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReserveCinema.Infrastructure.Persistence.Repositories;
public class ReservationRepository : IReservationRepository
{

    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        return await _context.Reservations
            .Include(r => r.ReservationSeats)
            .ThenInclude(rs => rs.Seat)
            .ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(int id)
    {
        return await _context.Reservations
            .Include(r => r.ReservationSeats)
            .ThenInclude(rs => rs.Seat)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}