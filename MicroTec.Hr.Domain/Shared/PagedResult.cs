namespace MicroTec.Hr.Domain.Shared
{
    public class PagedResult<T> where T : BaseEntity
    {
        public IEnumerable<T> Items { get; set; } = [];
        public int TotalCount { get; set; }
    }
}
