

namespace StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities.Bases
{
    public class BasePaginationFiltersEntity
    {
        public int NumberPage { get; set; } = 1;
        public int NumberRecordsPage { get; set; } = 10;
        private int NumberMaxRecordsPage { get; set; } = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;
        public int Records
        {
            get => NumberRecordsPage;
            set { NumberRecordsPage = value > NumberMaxRecordsPage ? NumberMaxRecordsPage : value; }
        }
    }
}
