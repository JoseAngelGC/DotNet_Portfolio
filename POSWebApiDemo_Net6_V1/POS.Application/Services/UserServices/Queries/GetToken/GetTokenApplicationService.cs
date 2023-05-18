using POS.Application.Interfaces.UserServices.Queries.GetToken;
using POS.Application.Validators.UserValidators.Queries.GetTokenRequest;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetToken;

namespace POS.Application.Services.UserServices.Queries.GetToken
{
    public class GetTokenApplicationService : QueryApplicationBasicHelpersHub, IGetTokenApplicationService
    {
        private readonly IGetTokenInteractor _getTokenInteractor;
        private readonly TokenRequestDtoValidator _tokenRequestValidator;
        public GetTokenApplicationService(IGetTokenInteractor getTokenInteractor, TokenRequestDtoValidator tokenRequestValidator)
        {
            _getTokenInteractor = getTokenInteractor;
            _tokenRequestValidator = tokenRequestValidator;
        }
        public async Task<GenericQueryApplicationResponseDto<string>> ResponseAsync(TokenRequestDto tokenRequestDto)
        {
            try
            {
                var validationResult = await _tokenRequestValidator.ValidateAsync(tokenRequestDto);
                if (!validationResult.IsValid)
                {
                    return await QueryApplicationValidationErrorsBasicCustomResponseAsync<string>(validationResult.Errors);
                }

                var interactorResponse = await _getTokenInteractor.TokenResponseAsync(tokenRequestDto);
                if (interactorResponse.TokenString is null)
                {
                    switch (interactorResponse.IsSuccess)
                    {
                        case false:
                            var interactorErrorCollectorResponse = await QueryApplicationResponseTypesCollectorAsync<string>(interactorResponse);
                            return await QueryApplicationBasicServiceResponseAsync(interactorErrorCollectorResponse);

                        case true:
                            var notFoundCollectorResponse = await QueryApplicationResponseTypesCollectorAsync<string>(interactorResponse);
                            return await QueryApplicationBasicServiceResponseAsync(notFoundCollectorResponse);
                    }
                }

                var tokenSuccessfulCollector = await QueryApplicationResponseTypesCollectorAsync<string>(interactorResponse);
                return await QueryApplicationBasicServiceResponseAsync(tokenSuccessfulCollector);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryApplicationExceptionBasicCollectorAsync<string>(8100, e.Message, e.HResult, e.Source);
                return await QueryApplicationBasicServiceResponseAsync(exceptionCollectorResponse);
            }
            
        }
    }
}
