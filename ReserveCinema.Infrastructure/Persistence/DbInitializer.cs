using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Infrastructure.Persistence;

public class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Shows.Any())
            return; // Ya hay datos

        var show = new Show
        {
            MovieTitle = "Avengers: Endgame",
            StartTime = DateTime.UtcNow.AddHours(2)
        };

        context.Shows.Add(show);
        context.SaveChanges();

        var seats = new List<Seat>();
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 1; col <= 5; col++)
            {
                seats.Add(new Seat
                {
                    Row = row,
                    Column = col,
                    IsAvailable = true,
                    ShowId = show.Id
                });
            }
        }

        context.Seats.AddRange(seats);
        context.SaveChanges();
    }
}
