using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Domain.Entities;

public class Show
{
    public int Id { get; set; }
    public string MovieTitle { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
