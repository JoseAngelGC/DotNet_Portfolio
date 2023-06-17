using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors.Bases;

namespace POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors
{
    public class InteractorTokenCollectorEntity : TokenCollectorBaseEntity
    {
        public string? TokenString { get; set; }
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
