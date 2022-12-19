namespace blog03.HotNews
{
    public class HotNewsJobItem<T>
    {
        public T Result { get; set; }
        public HotNewsEnum Source { get; set; }
    }
}
