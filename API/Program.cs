var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Section after .Build() is for middlewear
// i.e opportunity to perform actions on requests 
// before they reach a destination

// middlewear for development only
// if (app.Environment.IsDevelopment()){}

//app.UseHttpsRedirection(); -> redirects htpp to https (not necessary)
//app.UseAuthorization(); -> for authentication (later)
app.MapControllers(); // -> middlewear to map API endpoints to controllers

app.Run();
