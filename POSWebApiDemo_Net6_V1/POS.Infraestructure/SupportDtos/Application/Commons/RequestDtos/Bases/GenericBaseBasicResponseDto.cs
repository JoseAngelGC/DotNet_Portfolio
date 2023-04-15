

namespace POS.Infraestructure.SupportDtos.Application.Commons.RequestDtos.Bases
{
    public abstract class GenericBaseBasicResponseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}
