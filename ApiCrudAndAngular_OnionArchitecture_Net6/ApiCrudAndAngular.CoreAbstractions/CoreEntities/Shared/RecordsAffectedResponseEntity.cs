using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Shared
{
    public class RecordsAffectedResponseEntity : BaseResponseEntity
    {
        public int? RecordsAffected { get; set; }
    }
}
