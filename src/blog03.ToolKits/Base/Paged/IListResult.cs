namespace blog03.ToolKits.Base.Paged
{
    public interface IListResult<T>
    {
        IReadOnlyList<T> Item { get; set; }
    }
}
