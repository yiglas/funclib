using System;
using funclib.Components.Core.Generic;

namespace funclib.Collections.Generic
{
    public class EnumeratorSeq<T> :
        IFunction<T>
    {
        System.Collections.Generic.IEnumerator<T> _enumerator;

        EnumeratorSeq(System.Collections.Generic.IEnumerator<T> enumerator)
        {
            this._enumerator = enumerator;
        }

        #region Creates
        public static ISeq<T> Create(System.Collections.Generic.IEnumerator<T> enumerator)
        {
             if (!enumerator.MoveNext())
             {
                 return null;
             }

             return new funclib.Components.Core.Generic.LazySeq<T>(new EnumeratorSeq<T>(enumerator));
        }
        #endregion

        #region Functions
        public T Invoke()
        {
            var arr = new T[Constants.CHUNK_SIZE];
            var more = true;
            int n = 0;
            for (; n < Constants.CHUNK_SIZE && more; ++n)
            {
                arr[n] = this._enumerator.Current;
                more = this._enumerator.MoveNext();
            }

            // ISeq<ChunkedCons<T>> seq = null;
            // if (more)
            // {
            //     seq = Create(this._enumerator);
            // }

            throw new NotImplementedException();
            //return new ChunkedCons<T>(new ArrayChunked<T>(arr, 0, n), seq);
        }
        #endregion
    }
}
