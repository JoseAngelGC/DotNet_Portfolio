namespace POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateCategory { get; set; }
    }
}
