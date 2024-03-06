using Microsoft.AspNetCore.Mvc;
using RiaMoneyTransfer.ApplicationCore.Helpers;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Infrastructure;
using RiaMoneyTransfer.ApplicationCore.Interfaces.Services;
using RiaMoneyTransfer.ApplicationCore.Services;
using RiaMoneyTransfer.Infrastructure.Repositories;
using RiaMoneyTransfer.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
{
    // Add logging providers as needed
    builder.AddConsole();
    builder.AddDebug();
    // Add other providers such as File, EventSource, etc.
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(o =>
{
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

Config.ConnectionString = app.Configuration.GetConnectionString("DataBaseConnection") ?? throw new ArgumentNullException("Couldn't get DataBase Connection String!");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionLoggingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();