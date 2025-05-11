using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Application.DTOs;

namespace ReserveCinema.Application.Interfaces;

public interface IReservationService
{
    Task<int> CreateReservationAsync(CreateReservationDto dto);
}
