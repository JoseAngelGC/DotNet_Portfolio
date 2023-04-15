using POS.Infraestructure.SupportEntities.Commons.Requests.Bases;

namespace POS.Infraestructure.SupportDtos.Commons.Requests
{
    public class GenericFiltersRequestDto : PaginationFiltersBaseEntity
    {
        public int? NumberFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
        public int? StateFilter { get; set; } = null;
        public string? StartDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
        public bool? Download { get; set; } = false;
    }
}
