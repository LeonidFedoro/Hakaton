using hahahton.Services.Interfaces;
using hahahton.Services;
using hahahton.Repositories;
using hahahton.Repositories.Interfaces;
using hahahton.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� ��������
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IHashService, HashService>();

// ����������� ������������
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ��������� CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:5173") // ��������� ������� ������ � ����� ���������
                .AllowAnyMethod() // ��������� ��� HTTP-������
                .AllowAnyHeader(); // ��������� ��� ���������
        });
});

// ��������� ������� � ���������.
builder.Services.AddControllers();

var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ��������� CORS ����� ������������ � ��������������
app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();