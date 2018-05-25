using funcx.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    class Enumerator<T> : 
        IEnumerator, 
        IEnumerator<T>
        where T : new()
    {
        bool _realized;
        IEnumerable<T> _orig;
        T _curr;
        IEnumerable<T> _next;

        readonly T _start = new T();

        public Enumerator(IEnumerable<T> o)
        {
            this._realized = false;
            this._curr = this._start;
            this._orig = o;
            this._next = o;
        }

        public object Current
        {
            get
            {
                if (this._next == null)
                    throw new InvalidOperationException("No current value.");

                if (this._curr.Equals(this._start))
                    this._curr = new First<T>().Invoke(this._next);

                return this._curr;
            }
        }

        T IEnumerator<T>.Current => (T)Current;

        public bool MoveNext()
        {
            if (this._next == null) return false;

            this._curr = this._start;
            if (!this._realized)
            {
                this._realized = true;
                this._next = funcx.Util.Seq<T>(this._next);
            }
            else
                this._next = new Next<T>().Invoke(this._next);

            return this._next != null;
        }

        public void Reset()
        {
            this._realized = false;
            this._curr = this._start;
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
