using GreenGoat.Core.Interfaces;
using GreenGoat.Infrastructure.Data;
using GreenGoat.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
.AddEnvironmentVariables();

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//DI container registration
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
