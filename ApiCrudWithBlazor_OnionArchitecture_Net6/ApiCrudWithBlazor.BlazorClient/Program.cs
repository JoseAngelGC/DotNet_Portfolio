using ApiCrudWithBlazor.BlazorClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ApiCrudWithBlazor.BlazorClient.DomainModels.CoreAbstractions.Services;
using ApiCrudWithBlazor.BlazorClient.DomainServices;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7203/") });

//Register services
builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();
builder.Services.AddScoped<IProductApiService, ProductApiService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
