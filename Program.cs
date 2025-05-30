using Microsoft.EntityFrameworkCore;
using Ventixe.BookingService.Data;
using Ventixe.BookingService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<BookingService>();

builder.Services.AddDbContext<BookingDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient("NotificationService", client =>
{
    client.BaseAddress = new Uri("https://localhost:7018");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
