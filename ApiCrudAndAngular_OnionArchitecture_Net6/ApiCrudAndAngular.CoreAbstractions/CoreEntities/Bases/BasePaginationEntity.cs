

namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Bases
{
    public abstract class BasePaginationEntity
    {
        public int NumberPage { get; set; } = 1;
        public int NumberRecordsPage { get; set; } = 10;
        public string OrderType { get; set; } = "asc";
        public string? SortByColumn { get; set; } = null;
    }
}
