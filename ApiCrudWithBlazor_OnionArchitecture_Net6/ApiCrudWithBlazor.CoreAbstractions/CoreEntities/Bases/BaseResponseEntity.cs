namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Bases
{
    public abstract class BaseResponseEntity
    {
        public string? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
}
