namespace MicroTec.Hr.Domain.Shared
{
    public class PagedResult<T> where T : BaseModel
    {
        public IEnumerable<T> Items { get; set; } = [];
        public int TotalCount { get; set; }
    }
}
