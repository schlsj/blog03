using blog03.ToolKits.Base.Paged;

namespace blog03.ToolKits.Base
{
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        public int Total { get; set; }

        public PagedList()
        {

        }

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
