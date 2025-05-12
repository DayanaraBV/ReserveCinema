using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveCinema.Application.DTOs;

namespace ReserveCinema.Application.Interfaces;

public interface IShowService
{
    Task<int> CreateAsync(CreateShowDto dto);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, UpdateShowDto dto);
}
