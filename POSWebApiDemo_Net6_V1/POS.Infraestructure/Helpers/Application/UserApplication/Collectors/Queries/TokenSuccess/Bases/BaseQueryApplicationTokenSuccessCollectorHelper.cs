using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.UserApplication.Collectors.Queries.TokenSuccess.Bases
{
    public abstract class BaseQueryApplicationTokenSuccessCollectorHelper
    {
        public abstract Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(InteractorCreateTokenResponseDto interactorResponseDto);
    }
}
