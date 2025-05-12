using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Application.DTOs;
using ReserveCinema.Application.Interfaces;
using ReserveCinema.Domain.Entities;
using ReserveCinema.Domain.Interfaces;

namespace ReserveCinema.Application.UseCases;

public class ShowService : IShowService
{
    private readonly IShowRepository _repository;

    public ShowService(IShowRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateAsync(CreateShowDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.MovieTitle))
            throw new Exception("El título de la película es obligatorio.");

        if (dto.StartTime <= DateTime.UtcNow)
            throw new Exception("La hora de inicio debe estar en el futuro.");

        var show = new Show
        {
            MovieTitle = dto.MovieTitle,
            StartTime = DateTime.SpecifyKind(dto.StartTime, DateTimeKind.Utc)
        };

        await _repository.AddAsync(show);
        return show.Id;
    }
    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
    public async Task UpdateAsync(int id, UpdateShowDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.MovieTitle))
            throw new Exception("El título de la película es obligatorio.");

        if (dto.StartTime <= DateTime.UtcNow)
            throw new Exception("La hora debe ser futura.");

        await _repository.UpdateAsync(id, dto.MovieTitle, DateTime.SpecifyKind(dto.StartTime, DateTimeKind.Utc));
    }
    public async Task<object?> GetByIdAsync(int id)
    {
        var show = await _repository.GetByIdAsync(id);
        if (show == null) return null;

        return new
        {
            show.Id,
            show.MovieTitle,
            show.StartTime
        };
    }
}
