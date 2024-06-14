using EmployeeManagementSystem.Common;
using EmployeeManagementSystem.CosmoDB;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Interface;
using EmployeeManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeAdditionalDetailsService, EmployeeAdditionalDetailsService>();
builder.Services.AddScoped<IEmployeeBasicDetailsService, EmployeeBasicDetailsService>();
builder.Services.AddScoped<ICosmoDBService, CosmoDBService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
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
