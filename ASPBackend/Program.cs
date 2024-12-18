using DotNetEnv;
using Microsoft.EntityFrameworkCore;

using ASPBackend.Data;

// Initialize the application
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Load .env file
Env.Load();
var dbURl = Env.GetString("DB_URL");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();
services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbURl));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();