

namespace StoreBasicCRUD.BlazorCoreStructure.ResponsesApi
{
    public class QueryResponseApi<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
        public T? Data { get; set; }
        public int? Records { get; set; }
        public string? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
}
