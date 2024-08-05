using MediatR;
using ParasutIntegration.Features.Warehouse.Queries;
using ParasutIntegration.Models.Warehouse;
using ParasutIntegration.Models;
using ParasutIntegration.Features;
using ParasutIntegration.Models.Product;
using ParasutIntegration.Features.Product.Queries;
using ParasutIntegration.Models.Account;
using ParasutIntegration.Features.Account.Queries;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ParasutIntegration.Services;
using static ParasutIntegration.Services.IHttpService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHttpService, HttpService>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
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
