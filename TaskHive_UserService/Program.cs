using Microsoft.EntityFrameworkCore;
using System;
using TaskHive_UserService.Repositories.Interfaces;
using TaskHive_UserService.Repositories;
using TaskHive_UserService.Services.Interfaces;
using TaskHive_UserService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

// ----- Azure Production -----
//var azureConnectionString = Environment.GetEnvironmentVariable("AzureSQLConnection");

//builder.Services.AddDbContext<TaskHive_UserService.AppDbContext>( options =>
//    options.UseSqlServer(azureConnectionString));

// ----- Local Development -----
builder.Services.AddDbContext<TaskHive_UserService.AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("LocalSQLConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();

var app = builder.Build();

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
