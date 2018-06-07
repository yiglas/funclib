using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Concat :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        public object Invoke() => new LazySeq(new Function<object>(() => null)).Invoke();
        public object Invoke(object x) => new LazySeq(new Function<object>(() => x)).Invoke();
        public object Invoke(object x, object y) =>
            new LazySeq(new Function<object>(() =>
            {
                var s = new Seq().Invoke(x);
                if (new Truthy().Invoke(s))
                {
                    if (new IsChunkedSeq().Invoke(s))
                        return new ChunkCons().Invoke(new ChunkFirst().Invoke(s), Invoke(new ChunkRest().Invoke(s), y));
                    else
                        return new Cons().Invoke(new First().Invoke(s), Invoke(new Rest().Invoke(s), y));
                }
                else
                    return y;
            }));
        public object Invoke(object x, object y, params object[] zs)
        {
            Func<object, object, object> cat = null;
            cat = (xys, zss) =>
                new LazySeq(new Function<object>(() =>
                {
                    xys = new Seq().Invoke(xys);
                    if (new Truthy().Invoke(xys))
                    {
                        if (new IsChunkedSeq().Invoke(xys))
                            return new ChunkCons().Invoke(new ChunkFirst().Invoke(xys), cat(new ChunkRest().Invoke(xys), zs));
                        else
                            return new Cons().Invoke(new First().Invoke(xys), cat(new Rest().Invoke(xys), zs));
                    }
                    else if (new Truthy().Invoke(zss))
                    {
                        return cat(new First().Invoke(zss), new Next().Invoke(zss));
                    }
                    else
                        return null;
                }));

            return cat(Invoke(x, y), zs);
        }
    }
}
