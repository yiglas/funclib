using funcx.Collections;
using funcx.Collections.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class LazySeq<T> :
        IFunction<IEnumerable<T>>,
        IEnumerable<T>,
        IEnumerable
        where T : new()
    {
        IFunction<IEnumerable<T>> _fn;
        object _sv;
        IEnumerable<T> _s;

        public LazySeq(IFunction<IEnumerable<T>> fn)
        {
            this._fn = fn;
        }

        public IEnumerable<T> Invoke()
        {
            sval();

            if (this._sv != null)
            {
                object ls = this._sv;
                this._sv = null;

                while (ls is LazySeq<T> s)
                    ls = s.sval();

                this._s = Util.Seq<T>(ls);
            }

            return this._s;
        }

        object sval()
        {
            if (this._fn != null)
            {
                this._sv = this._fn.Invoke();
                this._fn = null;
            }
            if (this._sv != null)
                return this._sv;

            return this._s;
        }

        public IEnumerator GetEnumerator() => new Enumerator<T>(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(this);
    }
}
