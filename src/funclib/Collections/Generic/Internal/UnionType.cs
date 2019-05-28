namespace funclib.Collections.Generic.Internal
{
    public class UnionType<TItem1, TItem2>
    {
        public TItem1 Item1 { get; }
        public TItem2 Item2 { get; }

        public UnionType(TItem1 item1, TItem2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public UnionType(TItem1 item1)
        {
            this.Item1 = item1;
        }

        public UnionType(TItem2 item2)
        {
            this.Item2 = item2;
        }
    }
}