using POS.Infraestructure.Helpers.Application.Commons.Responses.Bases;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Responses
{
    public class QueryApplicationBasicServiceResponseHelper : BaseQueryApplicationBasicServiceResponseHelper
    {
        public override Task<GenericQueryApplicationResponseDto<T>> ResponseAsync<T>(QueryApplicationCollectorEntity<T> entity)
        {
            GenericQueryApplicationResponseDto<T> responseDto = new ();
            responseDto.IsSuccess = entity.IsSuccess;
            responseDto.MessageResponse = entity.MessageResponse;
            responseDto.Information = entity.Information;
            responseDto.StatusResponse = entity.HttpStatus;
            responseDto.Records = entity.Records;
            responseDto.Data = entity.Data;
            responseDto.ValidationErrors = entity.ValidationErrors;

            return Task.FromResult(responseDto);
        }
    }
}
