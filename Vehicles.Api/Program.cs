using Vehicles.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IVehiclesRepository, VehiclesRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
