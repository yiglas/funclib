using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class LazySeq :
        Collections.LazySeq,
        IFunction<ISeq>
    {
        public LazySeq(IFunction<object> fn) : base(fn) { }
        public LazySeq(ISeq seq) : base(seq) { }

        //readonly Collections.LazySeq _lazy;

        //public LazySeq(IFunction<object> fn)
        //{
        //    this._lazy = new Collections.LazySeq(fn);
        //}

        public ISeq Invoke() => Seq();
    }
}