using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;


namespace POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses
{
    public class InteractorCreateTokenResponseDto : ResponseBaseEntity
    {
        public string? TokenString { get; set; }
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
