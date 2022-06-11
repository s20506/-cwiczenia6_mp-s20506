using APBD_5.Services;
using App.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// TODO Remove 
app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();