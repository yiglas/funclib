﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Keep :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
        public object Invoke(object f, object coll) =>
            new LazySeq(() =>
            {
                var s = (ISeq)new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new IsChunkedSeq().Invoke(s))
                    {
                        var c = new ChunkFirst().Invoke(s);
                        var size = (int)new Count().Invoke(c);
                        var b = new ChunkBuffer().Invoke(size);

                        new DoTimes(size, i =>
                        {
                            var y = ((IFunction<object, object>)f).Invoke(new Nth().Invoke(c, i));
                            if (!(bool)new IsNull().Invoke(y))
                            {
                                new ChunkAppend().Invoke(b, y);
                            }
                            return null;
                        }).Invoke();

                        return new ChunkCons().Invoke(new Chunk().Invoke(b), Invoke(f, new ChunkRest().Invoke(s)));
                    }

                    var x = ((IFunction<object, object>)f).Invoke(s.First());
                    if ((bool)new IsNull().Invoke(x))
                    {
                        return Invoke(f, new Rest().Invoke(s));
                    }

                    return new Cons().Invoke(x, Invoke(f, new Rest().Invoke(s)));
                }

                return null;
            });

        public class TransducerFunction :
            ATransducerFunction
        {
            object _f;

            public TransducerFunction(object f, object rf) : 
                base(rf)
            {
                this._f = f;
            }

            #region Overrides
            public override object Invoke(object result, object input)
            {
                var v = ((IFunction<object, object>)this._f).Invoke(input);
                if ((bool)new IsNull().Invoke(v))
                    return result;

                return ((IFunction<object, object, object>)this._rf).Invoke(result, v);
            }
            #endregion
        }
    }
}
