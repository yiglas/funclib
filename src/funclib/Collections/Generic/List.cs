namespace funclib.Collections.Generic
{
    public class List<T> :
        ASeq<T>
        //IReduce
    {
        public static readonly IList<T> EMPTY = new EmptyList<T>();

        readonly T _first;
        readonly IList<T> _rest;

        internal List(T first) : this(first, null, 1) { }
        internal List(T first, IList<T> rest, int count)
        {
            this._first = first;
            this._rest = rest;
            Count = count;
        }

        #region Creates
        public static IList<T> Create(System.Collections.Generic.List<T> init)
        {
            ICollection<T> ret = EMPTY;

            for (int i = init.Count - 1; i >= 0; --i)
                ret = ret.Cons(init[i]);

            return ret as IList<T>;
        }

        public static IList<T> Create(params T[] init)
        {
            ICollection<T> ret = EMPTY;

            for (int i = init.Length - 1; i >= 0; --i)
                ret = ret.Cons(init[i]);

            return ret as IList<T>;
        }
        #endregion

        #region Overrides
        public override int Count { get; }
        public override ISeq<T> Cons(T o) => new List<T>(o, this, Count + 1);
        public override T First() => this._first;
        public override ISeq<T> Next()
        {
            if (Count == 1)
                return null;

            return this._rest; 
        }
        public override IStack<T> Pop()
        {
            if (this._rest is null)
                return EMPTY;

            return this._rest;
        }
        #endregion
    }
}
