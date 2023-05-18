using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces.UserServices.Commands.SaveItem;
using POS.Application.Interfaces.UserServices.Queries.GetToken;
using POS.Application.Services.UserServices.Commands.SaveItem;
using POS.Application.Services.UserServices.Queries.GetToken;
using POS.Application.Validators.UserValidators.Commands.SaveItemRequest;
using POS.Application.Validators.UserValidators.Queries.GetTokenRequest;
using System.Reflection;

namespace POS.Application.Extensiones.UserExtensions
{
    public static class InjectionUserExtensionsApplication
    {
        public static IServiceCollection AddInjectionUserApplication(this IServiceCollection service, IConfiguration configuration)
        {
            //Configurations
            service.AddSingleton(configuration);
            service.AddValidatorsFromAssemblyContaining<UserRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddValidatorsFromAssemblyContaining<TokenRequestDtoValidator>(ServiceLifetime.Transient);
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Queries services
            service.AddScoped<IGetTokenApplicationService, GetTokenApplicationService>();

            //Commands services
            service.AddScoped<ISaveUserApplicationService, SaveUserApplicationService>();

            return service;
        }
    }
}
