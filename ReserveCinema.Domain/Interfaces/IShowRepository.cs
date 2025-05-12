using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Domain.Interfaces;

public interface IShowRepository
{
    Task<Show?> GetByIdAsync(int id);
    Task<IEnumerable<Show>> GetAllAsync();
    Task AddAsync(Show show);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, string movieTitle, DateTime startTime);
}
