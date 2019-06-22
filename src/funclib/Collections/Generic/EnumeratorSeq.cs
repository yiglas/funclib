using System;
using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic
{
    public class EnumeratorSeq<T> :
        ASeq<T>
    {
        sealed class State
        {
            internal volatile object _val;
            internal volatile object _rest;
        }

        readonly System.Collections.Generic.IEnumerator<T> _enumerator;
        readonly State _state;

        EnumeratorSeq(System.Collections.Generic.IEnumerator<T> enumerator)
        {
            this._enumerator = enumerator;
            this._state = new State();
            this._state._val = this._state;
            this._state._rest = this._state;
        }

        #region Creates
        public static EnumeratorSeq<T> Create(System.Collections.Generic.IEnumerator<T> enumerator)
        {
             if (!enumerator.MoveNext())
             {
                 return null;
             }

             return new EnumeratorSeq<T>(enumerator);
        }
        #endregion

        #region Overrides
        public override UnionType<T, Nil> First()
        {
            if (this._state._val == this._state)
            {
                lock (this._state)
                {
                    if (this._state._val == this._state)
                    {
                        this._state._val = this._enumerator.Current;
                    }
                }
            }

            return (T)this._state._val;
        }

        public override ISeq<T> Next()
        {
            if (this._state._rest == this._state)
            {
                lock (this._state)
                {
                    if (this._state._rest == this._state)
                    {
                        First();
                        this._state._rest = this._enumerator.MoveNext() ? new EnumeratorSeq<T>(this._enumerator) : null;
                    }
                }
            }

            return (ISeq<T>)this._state._rest;
        }

        public override IStack<T> Pop() => throw new NotImplementedException();
        #endregion
    }
}
