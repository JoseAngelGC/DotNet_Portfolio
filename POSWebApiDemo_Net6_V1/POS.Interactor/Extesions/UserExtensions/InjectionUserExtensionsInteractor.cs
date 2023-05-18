using Microsoft.Extensions.DependencyInjection;
using POS.Interactor.InteractorServices.UserInteractors.Commands.SaveItem;
using POS.Interactor.InteractorServices.UserInteractors.Queries.GetToken;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Commands.SaveItem;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetToken;


namespace POS.Interactor.Extesions.UserExtensions
{
    public static class InjectionUserExtensionsInteractor
    {
        public static IServiceCollection AddInjectionUserInteractor(this IServiceCollection service)
        {
            //Queries Services
            service.AddTransient<IGetTokenInteractor, GetTokenInteractor>();

            //Commands Services
            service.AddTransient<ISaveUserInteractor, SaveUserInteractorService>();

            return service;

        }
    }
}
