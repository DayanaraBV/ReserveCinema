using ReserveCinema.Application.DTOs;
using ReserveCinema.Application.Interfaces;
using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;

namespace ReserveCinema.Application.UseCases;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepo;
    private readonly ISeatRepository _seatRepo;
    private readonly IShowRepository _showRepo;

    public ReservationService(
        IReservationRepository reservationRepo,
        ISeatRepository seatRepo,
        IShowRepository showRepo)
    {
        _reservationRepo = reservationRepo;
        _seatRepo = seatRepo;
        _showRepo = showRepo;
    }

    public async Task<int> CreateReservationAsync(CreateReservationDto dto)
    {
        var show = await _showRepo.GetByIdAsync(dto.ShowId)
            ?? throw new Exception("La función no existe.");

        var availableSeats = await _seatRepo.GetAvailableSeatsAsync(dto.ShowId);
        var selectedSeats = availableSeats.Where(s => dto.SeatIds.Contains(s.Id)).ToList();

        if (selectedSeats.Count != dto.SeatIds.Count)
            throw new Exception("Una o más butacas ya están ocupadas.");

        var reservation = new Reservation
        {
            CustomerName = dto.CustomerName,
            ReservedAt = DateTime.UtcNow,
            ShowId = dto.ShowId,
            ReservationSeats = selectedSeats.Select(seat => new ReservationSeat
            {
                SeatId = seat.Id
            }).ToList()
        };

        await _reservationRepo.AddAsync(reservation);
        await _seatRepo.ReserveSeatsAsync(dto.ShowId, dto.SeatIds);

        return reservation.Id;
    }
}
