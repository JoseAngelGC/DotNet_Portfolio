
namespace ApiCrudAndAngular.Entities.ApiCrud.SQLServer.SPs.POCOs
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public string Curp { get; set; }
        public string Telephone { get; set; }
        public double Salary { get; set; }
        public string JobPositionName { get; set; }
        public string DepartmentName { get; set; }
    }
}
