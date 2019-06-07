using System;
using funclib.Components.Core.Generic;

namespace funclib.Collections
{
    public class EnumeratorSeq :
        ASeq
    {
        sealed class State
        {
            internal volatile object _val;
            internal volatile object _rest;
        }

        readonly System.Collections.IEnumerator _enumerator;
        readonly State _state;

        EnumeratorSeq(System.Collections.IEnumerator enumerator)
        {
            this._enumerator = enumerator;
            this._state = new State();
            this._state._val = this._state;
            this._state._rest = this._state;
        }

        #region Creates
        public static EnumeratorSeq Create(System.Collections.IEnumerator enumerator)
        {
            bool hasElements = enumerator.MoveNext();

            if (hasElements)
            {
                return new EnumeratorSeq(enumerator);
            }

            return null;
        }
        #endregion

        #region Overrides
        public override object First()
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

            return this._state._val;
        }

        public override ISeq Next()
        {
            if (this._state._rest == this._state)
            {
                lock (this._state)
                {
                    if (this._state._rest == this._state)
                    {
                        First();
                        this._state._rest = this._enumerator.MoveNext() ? new EnumeratorSeq(this._enumerator) : null;
                    }
                }
            }

            return (ISeq)this._state._rest;
        }

        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}
