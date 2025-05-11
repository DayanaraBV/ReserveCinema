using Microsoft.AspNetCore.Mvc;
using ReserveCinema.Domain.Interfaces;

namespace ReserveCinema.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    private readonly IShowRepository _showRepository;

    public ShowController(IShowRepository showRepository)
    {
        _showRepository = showRepository;
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
}
