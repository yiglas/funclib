using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Filter :
        IFunction<object, object, object>
    {
        public object Invoke(object pred, object coll) =>
            new LazySeq(() =>
            {
                var fn = (IFunction<object, object>)pred;

                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new IsChunkedSeq().Invoke(s))
                    {
                        var c = new ChunkFirst().Invoke(s);
                        var size = (int)new Count().Invoke(c);
                        var b = (Collections.ChunkBuffer)new ChunkBuffer().Invoke(size);

                        new DoTimes(size, i =>
                        {
                            var v = new Nth().Invoke(c, i);
                            if ((bool)new Truthy().Invoke(fn.Invoke(v)))
                            {
                                return new ChunkAppend().Invoke(b, v);
                            }
                            return null;
                        }).Invoke();

                        return new ChunkCons().Invoke(b.Chunk(), Invoke(pred, new ChunkRest().Invoke(s)));
                    }
                    else
                    {
                        var f = new First().Invoke(s);
                        var r = new Rest().Invoke(s);

                        if ((bool)new Truthy().Invoke(fn.Invoke(f)))
                        {
                            return new Cons().Invoke(f, Invoke(pred, r));
                        }
                        else
                        {
                            return Invoke(pred, r);
                        }
                    }
                }

                return null;
            });
    }
}
