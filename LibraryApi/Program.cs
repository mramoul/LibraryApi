using LibraryApi.Api;
using LibraryApi.Infrastructure;
using LibraryApi.Application;

var builder = WebApplication.CreateBuilder(args);

// Add application services.
builder.AddApplicationServices();

// Add infrastructure services.
builder.AddInfrastructureServices();

// Build the app
var app = builder.Build();

// Add API endpoints
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