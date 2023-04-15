using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;


namespace POS.Infraestructure.SupportDtos.Interactors.Commons.Responses
{
    public class CommandInteractorResponseDto : ResponseBaseEntity
    {
        public int? AffectedRecords { get; set; }
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
