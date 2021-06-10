using System;

namespace funclib.Collections.Generic
{
    //public sealed class Cons<T> :
    //    ASeq<T>
    //{
    //    readonly T _first;
    //    readonly ISeq<T> _more;

    //    public Cons(T first, ISeq<T> more)
    //    {
    //        this._first = first;
    //        this._more = more;
    //    }

    //    #region Overrides
    //    public override int Count
    //    {
    //        get
    //        {
    //            // TODO:
    //            throw new NotImplementedException();
    //        }
    //    }

    //    public override T First()
    //    {
    //        return this._first;
    //    }

    //    public override ISeq<T> Next()
    //    {
    //        return More().Seq();
    //    }

    //    public override ISeq<T> More()
    //    {
    //        if (this._more is null)
    //        {
    //            return List<T>.EMPTY;
    //        }

    //        return this._more;
    //    }

    //    public override IStack<T> Pop()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion
    //}
}
