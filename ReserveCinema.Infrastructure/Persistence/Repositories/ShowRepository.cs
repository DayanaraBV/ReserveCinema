using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;
using ReserveCinema.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReserveCinema.Infrastructure.Persistence.Repositories;

public class ShowRepository : IShowRepository
{
    private readonly ApplicationDbContext _context;

    public ShowRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Show show)
    {
        await _context.Shows.AddAsync(show);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Show>> GetAllAsync()
    {
        return await _context.Shows.ToListAsync();
    }

    public async Task<Show?> GetByIdAsync(int id)
    {
        return await _context.Shows
            .Include(s => s.Seats)
            .Include(s => s.Reservations)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}