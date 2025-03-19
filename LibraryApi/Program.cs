using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using LibraryApi.Infrastructure;
using LibraryApi.Application.Authors;
using LibraryApi.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program).Assembly);

// Add DbContext to DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
builder.Services.AddSingleton<ICreateAuthorCommandMapper, CreateAuthorCommandMapper>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Minimal API endpoints
app.AddApiEndpoints();

// Activation de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Run the app
app.Run();
