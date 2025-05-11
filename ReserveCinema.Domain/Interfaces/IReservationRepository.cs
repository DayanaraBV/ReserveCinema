using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(int id);
    Task<IEnumerable<Reservation>> GetAllAsync();
    Task AddAsync(Reservation reservation);
}
