using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Domain.Interfaces;

public interface ISeatRepository
{
    Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showId);
    Task ReserveSeatsAsync(int showId, IEnumerable<int> seatIds);
}
