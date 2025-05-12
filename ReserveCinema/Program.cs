using ReserveCinema.Infrastructure.Persistence;
using ReserveCinema.Domain.Interfaces;
using ReserveCinema.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ReserveCinema.Application.Interfaces;
using ReserveCinema.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();


builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IShowService, ShowService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbInitializer.Seed(context);
}
app.Run();