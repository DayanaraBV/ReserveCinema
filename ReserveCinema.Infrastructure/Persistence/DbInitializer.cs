using ReserveCinema.Domain.Entities;

namespace ReserveCinema.Infrastructure.Persistence;

public static class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Shows.Any())
            return; 

        var shows = new List<Show>
        {
            new Show { MovieTitle = "Avengers: Endgame", StartTime = new DateTime(2025, 7, 1, 15, 0, 0, DateTimeKind.Utc) },
            new Show { MovieTitle = "El Conjuro", StartTime = new DateTime(2025, 7, 2, 18, 0, 0, DateTimeKind.Utc) },
            new Show { MovieTitle = "Barbie", StartTime = new DateTime(2025, 7, 3, 16, 30, 0, DateTimeKind.Utc) },
            new Show { MovieTitle = "Oppenheimer", StartTime = new DateTime(2025, 7, 4, 20, 0, 0, DateTimeKind.Utc) },
            new Show { MovieTitle = "Inside Out 2", StartTime = new DateTime(2025, 7, 5, 14, 0, 0, DateTimeKind.Utc) }
        };

        foreach (var show in shows)
        {
            show.Seats = new List<Seat>();

            for (int row = 1; row <= 2; row++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    show.Seats.Add(new Seat
                    {
                        Row = row,
                        Column = col,
                        IsAvailable = true
                    });
                }
            }

            context.Shows.Add(show);
        }

        context.SaveChanges();
    }
}
