using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Map :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
        public object Invoke(object f, object coll)
        {
            var fn = (IFunction<object, object>)f;
            return new LazySeq(() =>
            {
                var s = new Seq().Invoke(coll);
                if ((bool)new Truthy().Invoke(s))
                {
                    if ((bool)new IsChunkedSeq().Invoke(s))
                    {
                        var c = new ChunkFirst().Invoke(s);
                        var size = (int)new Count().Invoke(c);
                        var b = (Collections.ChunkBuffer)new ChunkBuffer().Invoke(size);

                        new DoTimes(size, i =>
                            new ChunkAppend().Invoke(b, fn.Invoke(new Nth().Invoke(c, i))))
                            .Invoke();

                        return new ChunkCons().Invoke(b.Chunk(), Invoke(f, new ChunkRest().Invoke(s)));
                    }
                    else
                        return new Core.Cons().Invoke(fn.Invoke(new First().Invoke(s)), Invoke(f, new Rest().Invoke(s)));
                }

                return null;
            });
        }
        public object Invoke(object f, object c1, object c2)
        {
            var fn = (IFunction<object, object, object>)f;
            return new LazySeq(() =>
            {
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                if ((bool)new Truthy().Invoke(new And().Invoke(s1, s2)))
                {
                    return new Core.Cons().Invoke(fn.Invoke(new First().Invoke(s1), new First().Invoke(s2)), Invoke(f, new Rest().Invoke(s1), new Rest().Invoke(s2)));
                }

                return null;
            });
        }
        public object Invoke(object f, object c1, object c2, object c3)
        {
            var fn = (IFunction<object, object, object, object>)f;
            return new LazySeq(() =>
            {
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                var s3 = new Seq().Invoke(c3);
                if ((bool)new Truthy().Invoke(new And().Invoke(s1, s2, s3)))
                {
                    return new Core.Cons().Invoke(fn.Invoke(new First().Invoke(s1), new First().Invoke(s2), new First().Invoke(s1)), Invoke(f, new Rest().Invoke(s1), new Rest().Invoke(s2), new Rest().Invoke(s3)));
                }

                return null;
            });
        }
        public object Invoke(object f, object c1, object c2, object c3, params object[] colls)
        {
            return Invoke(
                new Function<object, object>(x => new Apply().Invoke(f, x)),
                step(new Conj().Invoke(colls, c3, c2, c1)));

            object step(object cs) =>
                new LazySeq(() =>
                {
                    var ss = Invoke(new Seq(), cs);
                    if ((bool)new IsEvery().Invoke(new Identity(), ss))
                    {
                        return new Cons().Invoke(Invoke(new First(), ss), step(Invoke(new Rest(), ss)));
                    }

                    return null;
                });
        }

        
        public class TransducerFunction :
            ATransducerFunction,
            IFunctionParams<object, object, object, object>
        {
            object _f;

            public TransducerFunction(object f, object rf) :
                base(rf)
            {
                this._f = f;
            }

            #region Overrides
            public override object Invoke(object result, object input) => ((IFunction<object, object, object>)this._rf).Invoke(result, ((IFunction<object, object>)this._f).Invoke(input));
            #endregion

            public object Invoke(object result, object input, params object[] inputs) =>
                ((IFunction<object, object, object>)this._rf).Invoke(result, ((IFunction<object, object>)this._f).Invoke(new Apply().Invoke(this._f, input, inputs)));
        }
    }
}
