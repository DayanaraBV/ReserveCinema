using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;

namespace ReserveCinema.Infrastructure.Persistence.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly ApplicationDbContext _context;

    public SeatRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showId)
    {
        return await _context.Seats
            .Where(s => s.ShowId == showId && s.IsAvailable)
            .ToListAsync();
    }

    public async Task ReserveSeatsAsync(int showId, IEnumerable<int> seatIds)
    {
        var seats = await _context.Seats
            .Where(s => s.ShowId == showId && seatIds.Contains(s.Id))
            .ToListAsync();

        foreach (var seat in seats)
        {
            seat.IsAvailable = false;
        }

        await _context.SaveChangesAsync();
    }
}
