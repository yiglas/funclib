using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class LazySeq :
        Collections.LazySeq,
        IFunction<ISeq>
    {
        public LazySeq(object body) : this(() => body) { }
        public LazySeq(Func<object> fn) : base(new Function<object>(fn)) { }
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