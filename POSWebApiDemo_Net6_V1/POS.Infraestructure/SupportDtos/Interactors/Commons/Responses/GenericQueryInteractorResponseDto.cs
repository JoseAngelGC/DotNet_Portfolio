using POS.Infraestructure.SupportEntities.Commons.Responses.ResponseTypes;

namespace POS.Infraestructure.SupportDtos.Interactors.Commons.Responses
{
    public class GenericQueryInteractorResponseDto<T> : GenericCoreResponseEntity<T>
    {
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
