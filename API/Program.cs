using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
  opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add service to enable Cross Origins
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Section after .Build() is for middlewear
// i.e opportunity to perform actions on requests 
// before they reach a destination

// Add middlewear

// middlewear for development only
// if (app.Environment.IsDevelopment()){}

//app.UseHttpsRedirection(); -> redirects htpp to https (not necessary)
//app.UseAuthorization(); -> for authentication (later)

// Use added Cross Origin service (above) to allow all headers for any Http Method on the 
//... cross-origin of our Angular application.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.MapControllers(); // -> middlewear to map API endpoints to controllers

app.Run();
