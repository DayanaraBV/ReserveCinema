using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Application.DTOs;

public class CreateReservationDto
{
    public int ShowId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<int> SeatIds { get; set; } = new();
}
