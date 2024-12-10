using hahahton.Services.Interfaces;
using hahahton.Services;
using hahahton.Repositories;
using hahahton.Repositories.Interfaces;
using hahahton.Services;
using hahahton.Services.Interfaces;
using hahahton.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHashService, HashService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//        policy => policy.WithOrigins("http://localhost:5173")
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
