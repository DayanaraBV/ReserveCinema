using Microsoft.AspNetCore.Mvc;
using ReserveCinema.Application.DTOs;
using ReserveCinema.Application.Interfaces;
using ReserveCinema.Domain.Interfaces;

namespace ReserveCinema.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    private readonly ISeatRepository _seatRepository;

    public ReservationController(IReservationService reservationService, ISeatRepository seatRepository)
    {
        _reservationService = reservationService;
        _seatRepository = seatRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservationDto dto)
    {
        try
        {
            var reservationId = await _reservationService.CreateReservationAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = reservationId }, new { id = reservationId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {

        return Ok(new { message = $"Aquí se retornaría la reserva con ID {id}" });
    }
    [HttpGet("seats/{showId}")]
    public async Task<IActionResult> GetAvailableSeats(int showId)
    {
        try
        {
            var seats = await _seatRepository.GetAvailableSeatsAsync(showId);
            var response = seats.Select(s => new
            {
                s.Id,
                s.Row,
                s.Column,
                s.IsAvailable
            });

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetReservationDetails(int id)
    {
        try
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

