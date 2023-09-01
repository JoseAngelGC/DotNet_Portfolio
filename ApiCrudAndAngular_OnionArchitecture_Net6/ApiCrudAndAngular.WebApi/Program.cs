using ApiCrudAndAngular.ApplicationServices.Extensions;
using ApiCrudAndAngular.CoreServices.Extensions;
using ApiCrudAndAngular.SqlServerDataAccess.Extensions;
using ApiCrudAndAngular.UseCases.Extensions;
using ApiCrudAndAngular.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var corsName = "Cors";

// Add services to the container.
builder.Services.AddInjectionCoreServices();
builder.Services.AddInjectionSqlServerDataAccess(configuration);
builder.Services.AddInjectionUseCases();
builder.Services.AddInjectionApplicationServices();
builder.Services.AddInjectionWebApiServices(corsName);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(corsName);

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
