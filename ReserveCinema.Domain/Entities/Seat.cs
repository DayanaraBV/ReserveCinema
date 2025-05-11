using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Domain.Entities;

public class Seat
{
    public int Id { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsAvailable { get; set; }

    public int ShowId { get; set; }
    public Show Show { get; set; } = null!;

    public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
}
