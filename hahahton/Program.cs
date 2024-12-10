using hahahton.Services.Interfaces;
using hahahton.Services;
using hahahton.Repositories;
using hahahton.Repositories.Interfaces;
using hahahton.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрация сервисов
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHashService, HashService>();

// Регистрация репозиториев
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:5173") // Разрешает запросы только с этого источника
                .AllowAnyMethod() // Разрешает все HTTP-методы
                .AllowAnyHeader(); // Разрешает все заголовки
        });
});

// Добавляем сервисы в контейнер.
builder.Services.AddControllers();

var app = builder.Build();

// Настройка конвейера HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Применяем CORS перед авторизацией и маршрутизацией
app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();