using LibraryApi.Api;
using LibraryApi.Infrastructure;
using LibraryApi.Application;
using LibraryApi.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add application services.
builder.AddApplicationServices();

// Add infrastructure services.
builder.AddInfrastructureServices();

// Build the app
var app = builder.Build();

// Add Middlewares
app.UseMiddlewares();

// Add API endpoints
app.UseApiEndpoints();

// Swagger Activation
app.UseSwagger();
app.UseSwaggerUI(op =>{
    // Remove schemas gen.
op.DefaultModelsExpandDepth(-1);
op.EnableTryItOutByDefault();
});

// Migration for production Activation
if (app.Environment.IsProduction())
{    
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

// Run the app
app.Run();