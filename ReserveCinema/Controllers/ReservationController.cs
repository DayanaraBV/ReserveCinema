using Microsoft.AspNetCore.Mvc;
using ReserveCinema.Application.DTOs;
using ReserveCinema.Application.Interfaces;

namespace ReserveCinema.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
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
}
