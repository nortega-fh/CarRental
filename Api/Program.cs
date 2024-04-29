using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalContext>(options => options.UseSqlServer(builder.Configuration["Database:ConnectionString"]));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
