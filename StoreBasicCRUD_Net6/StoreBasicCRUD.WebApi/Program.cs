using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ApplicationServices.Extensions;
using StoreBasicCRUD.ControllersCoreStructure.Extensions;
using StoreBasicCRUD.Persistence_SQLServer.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var Cors = "Cors";

// Add services to the container.
builder.Services.AddInjectionApplication(configuration);
builder.Services.AddInjectionPersistence(configuration);
builder.Services.AddInjectionControllerCoreStructure();

//Cors service configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors, builder =>
    {
        builder.WithOrigins("*");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

//Versioning service configuration
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(Cors);

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
