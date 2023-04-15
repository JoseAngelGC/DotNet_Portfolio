using POS.Application.Extensiones.CategoryExtensions;
using POS.Interactor.Extesions.CategoryExtensions;
using POS.Persistence.Extensions;
using POS.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddInjectionPersistence(configuration);
builder.Services.AddInjectionCategoryInteractor();
builder.Services.AddInjectionCategoryApplication(configuration);
builder.Services.AddInjectionWebApi();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

public partial class Program { }
