using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Domain.Entities
{
    public class ReservationSeat
    {
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;

        public int SeatId { get; set; }
        public Seat Seat { get; set; } = null!;
    }
}
