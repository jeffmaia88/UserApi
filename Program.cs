using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Repositories;
using UserApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<UserDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();


