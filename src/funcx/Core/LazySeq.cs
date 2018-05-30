using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class LazySeq
    {
        readonly Collections.LazySeq _lazy;

        public LazySeq(IFunction<object> fn)
        {
            this._lazy = new Collections.LazySeq(fn);
        }

        public object Invoke() => new Seq().Invoke(_lazy);
    }
}