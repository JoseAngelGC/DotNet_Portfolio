using POS.Infraestructure.SupportEntities.Commons.Collectors.Bases;


namespace POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors
{
    public class CommandInteractorCollectorEntity : CollectorBaseEntity
    {
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
