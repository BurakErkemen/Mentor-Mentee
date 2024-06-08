using Microsoft.EntityFrameworkCore;
using ToDoAPI.Interfaces;
using ToDoAPI.Model;
using ToDoAPI.Repository;
using ToDoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with a connection string from configuration
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemsRepository, ItemsRepository>(); // Repository Katman� Dependency Enjection i�lemi
builder.Services.AddScoped<IItemsService, ItemsService>(); // Servis Katman� Dependency Enjection ��lemi

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
