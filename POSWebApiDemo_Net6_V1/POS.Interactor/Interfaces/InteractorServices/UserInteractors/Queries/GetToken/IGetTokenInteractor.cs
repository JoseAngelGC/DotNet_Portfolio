using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;


namespace POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetToken
{
    public interface IGetTokenInteractor
    {
        Task<InteractorCreateTokenResponseDto> TokenResponseAsync(TokenRequestDto tokenRequest);
    }
}
