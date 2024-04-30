using Api;
using Api.Vehicles;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalContext>(options => options.UseSqlServer(builder.Configuration["Database:ConnectionString"]));

builder.Services.AddValidatorsFromAssemblyContaining<VehicleValidator>();

builder.Services.AddInfrastructureRepositories();
builder.Services.AddDomainServices();
builder.Services.AddMappers();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
