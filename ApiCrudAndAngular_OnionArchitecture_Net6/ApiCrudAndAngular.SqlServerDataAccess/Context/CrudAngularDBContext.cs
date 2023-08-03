using Microsoft.EntityFrameworkCore;


namespace ApiCrudAndAngular.SqlServerDataAccess.Context
{
    public partial class CrudAngularDBContext : DbContext
    {
        public CrudAngularDBContext(DbContextOptions<CrudAngularDBContext> options): base(options)
        {
            
        }
    }
}
