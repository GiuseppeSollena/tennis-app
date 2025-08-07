using Api.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// CORS policy permissiva per sviluppo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.WebHost.UseUrls("http://0.0.0.0:5000");

var connectionString =
    Environment.GetEnvironmentVariable("CONNECTION_STRING");

//print log connectionString
Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<TennisDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
