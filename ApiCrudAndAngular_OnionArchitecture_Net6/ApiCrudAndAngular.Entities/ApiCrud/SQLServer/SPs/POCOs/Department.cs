using ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.Bases;

namespace ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs
{
    public class Department: BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
