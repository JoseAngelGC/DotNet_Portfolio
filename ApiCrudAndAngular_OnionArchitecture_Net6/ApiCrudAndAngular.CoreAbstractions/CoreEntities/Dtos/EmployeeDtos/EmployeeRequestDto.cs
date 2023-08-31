namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.EmployeeDtos
{
    public class EmployeeRequestDto
    {
        public string? Name { get; set; }
        public string? PaternalSurname { get; set; }
        public string? MaternalSurname { get; set; }
        public string? Curp { get; set; }
        public string? Telephone { get; set; }
        public double Salary { get; set; }
        public string? JobPosition { get; set; }
        public string? Department { get; set; }
    }
}
