namespace blog03.ToolKits.Base.Paged
{
    public class ListResult<T> : IListResult<T>
    {
        IReadOnlyList<T> _item;

        public IReadOnlyList<T> Item
        {
            get => _item ?? (_item = new List<T>());
            set => _item = value;
        }

        public ListResult()
        {

        }

        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}
