using funclib.Components.Core;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Collections.Internal
{
    class Enumerator : 
        System.Collections.IEnumerator
    {
        bool _realized;
        object _orig;
        object _curr;
        object _next;

        readonly object _start = new object();

        public Enumerator(ISeq o)
        {
            this._realized = false;
            this._curr = this._start;
            this._orig = o;
            this._next = o;
        }

        public Enumerator(object o)
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
                if (this._next is null)
                    throw new InvalidOperationException("No current value.");

                if (this._curr == this._start)
                    this._curr = first(this._next);

                return this._curr;
            }
        }
        
        public bool MoveNext()
        {
            if (this._next is null) return false;

            this._curr = this._start;
            if (!this._realized)
            {
                this._realized = true;
                this._next = seq(this._next);
            }
            else
                this._next = next(this._next);

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
