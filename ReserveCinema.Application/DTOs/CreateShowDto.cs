using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCinema.Application.DTOs;

public class CreateShowDto
{
    public string MovieTitle { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
}
