using FunctionalLibrary.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    public class EnumeratorSeq :
        IFunction<object>
    {
        IEnumerator _enumerator;

        EnumeratorSeq(IEnumerator enumerator)
        {
            this._enumerator = enumerator;
        }

        #region Creates
        public static ISeq Create(IEnumerator enumerator) => new LazySeq(new EnumeratorSeq(enumerator)); 
        #endregion

        #region Functions
        public object Invoke()
        {
            var arr = new object[Constants.CHUNK_SIZE];
            var more = true;
            int n = 0;
            for (; n < Constants.CHUNK_SIZE && more; ++n)
            {
                arr[n] = this._enumerator.Current;
                more = this._enumerator.MoveNext();
            }

            return new ChunkedCons(new ArrayChunked(arr, 0, n), more ? Create(this._enumerator) : null);
        }
        #endregion
    }
}
