using ApiCrudWithBlazor.ApplicationServices.Extensions;
using ApiCrudWithBlazor.Core.Extensions;
using ApiCrudWithBlazor.Repositories.Extensions;
using ApiCrudWithBlazor.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var Cors = "Cors";

// Add services to the container.
builder.Services.AddInjectionRepositories(configuration);
builder.Services.AddInjectionCore();
builder.Services.AddInjectionApplicationServices();
builder.Services.AddInjectionWebApiServices(Cors);
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
