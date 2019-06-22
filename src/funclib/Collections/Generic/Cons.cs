using System;

namespace funclib.Collections.Generic
{
    public class Cons<T> :
        ASeq<T>
    {
        readonly T _first;
        readonly ISeq<T> _more;

        public Cons(T first, ISeq<T> more)
        {
            this._first = first;
            this._more = more;
        }

        #region Overrides
        public override int Count => 1 + funclib.Generic.Core.Count(this._more);
        public override UnionType<T, Nil> First() => this._first;
        public override ISeq<T> Next() => More().Seq();
        public override ISeq<T> More() => this._more ?? List<T>.EMPTY;
        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion
    }
}
