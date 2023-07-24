using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Bases;

namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Shared
{
    public class RecordsAffectedResponseEntity : BaseResponseEntity
    {
        public int? RecordsAffected { get; set; }
    }
}
