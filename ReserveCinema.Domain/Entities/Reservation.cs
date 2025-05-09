using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; } = null!;

        public ICollection<ReservationSeat> ReservationSeats { get; set; } = new List<ReservationSeat>();
    }
}
