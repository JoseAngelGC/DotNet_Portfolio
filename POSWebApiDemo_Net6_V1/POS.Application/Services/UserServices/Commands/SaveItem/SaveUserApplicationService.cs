using AutoMapper;
using POS.Application.Interfaces.UserServices.Commands.SaveItem;
using POS.Application.Validators.UserValidators.Commands.SaveItemRequest;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Commands.SaveItem;
using POS.Utilities.Commons.Consts;

namespace POS.Application.Services.UserServices.Commands.SaveItem
{
    public class SaveUserApplicationService : CommandApplicationBasicHelpersHub, ISaveUserApplicationService
    {
        private readonly ISaveUserInteractor _saveUserInteractor;
        private readonly UserRequestDtoValidator _userRequestDtoValidator;
        private readonly IMapper _mapper;
        private bool isSuccessFlag = false;
        private int? affectedRecords;
        public SaveUserApplicationService(ISaveUserInteractor saveUserInteractor, UserRequestDtoValidator userRequestDtoValidator, IMapper mapper)
        {
            _saveUserInteractor = saveUserInteractor;
            _userRequestDtoValidator = userRequestDtoValidator;
            _mapper = mapper;
            isSuccessFlag = false;
            affectedRecords = 0;
            
        }
        public async Task<CommandApplicationResponseDto> SaveItemAsync(UserRequestDto userRequestDto)
        {
            try
            {
                var validationResult = await _userRequestDtoValidator.ValidateAsync(userRequestDto);
                if (!validationResult.IsValid)
                {
                    return await CommandApplicationValidationErrorsBasicCustomResponseAsync(validationResult.Errors);
                }

                var mapperCategoryEntity = _mapper.Map<User>(userRequestDto);
                var saveItemResponse = await _saveUserInteractor.SaveItemAsync(mapperCategoryEntity);
                isSuccessFlag = saveItemResponse.IsSuccess;
                affectedRecords = saveItemResponse.AffectedRecords;

                var collectorCommandResponse = await CommandApplicationBuildResponseTypeBasicCollectorAsync(saveItemResponse, ReplyMessage.MESSAGE_SAVE);
                return await CommandApplicationBasicServiceResponseAsync(collectorCommandResponse);
            }
            catch (Exception)
            {
                var collectorExceptionResponse = await CommandApplicationExceptionBasicCollectorAsync(affectedRecords, 4200, isSuccessFlag);
                return await CommandApplicationBasicServiceResponseAsync(collectorExceptionResponse);
            }
            
        }
    }
}
