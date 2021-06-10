using System.Collections.Generic;

namespace funclib.Collections.Generic.Internal
{
    //class Enumerator<T> :
    //    System.Collections.IEnumerator,
    //    System.Collections.Generic.IEnumerator<T>
    //{
    //    bool _realized;
    //    T _orig;
    //    T _curr;
    //    T _next;

    //    public Enumerator(ISeq<T> o)
    //    {
    //        this._realized = false;
    //        this._curr = this._start;
    //    }

    //    public object Current => throw new System.NotImplementedException();

    //    T IEnumerator<T>.Current => throw new System.NotImplementedException();

    //    public void Dispose()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public bool MoveNext()
    //    {
    //        if (this._next == null)
    //        {
    //            return false;
    //        }

    //        this._curr = this._start;

    //        if (!this._realized)
    //        {
    //            this._realized = true;
    //            this._next = funclib.Generic.Core.Seq(this._next);
    //        }
    //    }

    //    public void Reset()
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}
