using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;

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
    public async Task DeleteAsync(int id)
    {
        var show = await _context.Shows.FindAsync(id);
        if (show == null) return;

        _context.Shows.Remove(show);
        await _context.SaveChangesAsync();
    }
}
