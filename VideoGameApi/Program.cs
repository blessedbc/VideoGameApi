using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VideoGameDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//// Temporary debug — add and run the app once to see the printed connection string
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//Console.WriteLine("Using connection string: " + connectionString);
//builder.Services.AddDbContext<VideoGameDbContext>(options =>
//    options.UseSqlServer(connectionString));
//Console.ReadLine();
