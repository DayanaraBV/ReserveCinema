using Microsoft.AspNetCore.Mvc;
using ReserveCinema.Domain.Interfaces;
using ReserveCinema.Application.DTOs;
using ReserveCinema.Application.Interfaces;

namespace ReserveCinema.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    private readonly IShowRepository _showRepository;
    private readonly IShowService _showService;

    public ShowController(IShowRepository showRepository, IShowService showService)
    {
        _showRepository = showRepository;
        _showService = showService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var shows = await _showRepository.GetAllAsync();
            var response = shows.Select(show => new
            {
                show.Id,
                show.MovieTitle,
                show.StartTime
            });

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShowDto dto)
    {
        try
        {
            var id = await _showService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id }, new { id });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = ex.InnerException?.Message ?? ex.Message
            });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _showService.DeleteAsync(id);
            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
