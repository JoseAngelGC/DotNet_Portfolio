using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ExceptionResponses.Command;
using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ExceptionResponses.Query;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Services
{
    public class ExceptionResponseBasicsHelpersService : IExceptionResponseBasicsHelpersService
    {
        private BaseCommandExceptionHelper? _baseCommandExceptionHelper;
        private BaseQueryExceptionHelper? _baseQueryExceptionHelper;

        public async Task<CommandResponseDto> CommandExceptionHelperAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            _baseCommandExceptionHelper = new CommandExceptionBasicHelper();
            return await _baseCommandExceptionHelper.AttributesValuesResponseAsync(messageErrorException, hResultException, sourceException);
        }

        public async Task<QueryResponseDto<T>> QueryExceptionHelperAsync<T>(string? messageErrorException, int? hResultException, string? sourceException)
        {
            _baseQueryExceptionHelper = new QueryExceptionBasicHelper();
            return await _baseQueryExceptionHelper.AttributesValuesResponseAsync<T>(messageErrorException, hResultException, sourceException);
        }
    }
}
