
using System;
using System.Collections;

namespace funclib.Collections.Generic.Internal
{
    class Enumerator<T> :
        System.Collections.Generic.IEnumerator<T>
    {
        bool _realized;
        ISeqable<T> _orig;
        T _curr;
        ISeqable<T> _next;

        bool _start = true;

        public Enumerator(ISeq<T> o)
        {
            this._realized = false;
            this._start = true;
            this._orig = o;
            this._next = o;
        }

        public T Current
        {
            get
            {
                if (this._next is null)
                {
                    throw new InvalidOperationException("No current value.");
                }

                if (this._start)
                {
                    this._start = false;
                    this._curr = funclib.Generic.Core.First(this._next);
                }

                return this._curr;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (this._next is null)
            {
                return false;
            }

            this._start = true;
            if (!this._realized)
            {
                this._realized = true;
                this._next = funclib.Generic.Core.Seq(this._next);
            }
            else
            {
                this._next = funclib.Generic.Core.Next(this._next);
            }

            return this._next != null;
        }

        public void Reset()
        {
            this._realized = false;
            this._start = true;
            this._next = this._orig;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (!disposing) return;
            this._orig = null;
            this._curr = default;
            this._next = null;
        }
    }
}