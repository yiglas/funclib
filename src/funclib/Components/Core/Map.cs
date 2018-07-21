using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
    /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
    /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
    /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
    /// </summary>
    public class Map :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunction<object, object, object, object, object>,
        IFunctionParams<object, object, object, object, object, object>
    {
        public object Invoke(object f) => new Function<object, object>(rf => new TransducerFunction(f, rf));
        /// <summary>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="coll">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
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
                        var c = chunkFirst(s);
                        var size = (int)count(c);
                        var b = (Collections.ChunkBuffer)chunkBuffer(size);

                        doTimes(size, 
                            i => chunkAppend(b, fn.Invoke(new Nth().Invoke(c, i))));

                        return chunkCons(b.Chunk(), Invoke(f, chunkRest(s)));
                    }
                    else
                        return cons(fn.Invoke(new First().Invoke(s)), Invoke(f, new Rest().Invoke(s)));
                }

                return null;
            });
        }
        /// <summary>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2)
        {
            var fn = (IFunction<object, object, object>)f;
            return new LazySeq(() =>
            {
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                if ((bool)new Truthy().Invoke(and(s1, s2)))
                {
                    return cons(fn.Invoke(new First().Invoke(s1), new First().Invoke(s2)), Invoke(f, new Rest().Invoke(s1), new Rest().Invoke(s2)));
                }

                return null;
            });
        }
        /// <summary>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <param name="c3">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2, object c3)
        {
            var fn = (IFunction<object, object, object, object>)f;
            return new LazySeq(() =>
            {
                var s1 = new Seq().Invoke(c1);
                var s2 = new Seq().Invoke(c2);
                var s3 = new Seq().Invoke(c3);
                if ((bool)new Truthy().Invoke(and(s1, s2, s3)))
                {
                    return cons(fn.Invoke(new First().Invoke(s1), new First().Invoke(s2), new First().Invoke(s1)), Invoke(f, new Rest().Invoke(s1), new Rest().Invoke(s2), new Rest().Invoke(s3)));
                }

                return null;
            });
        }
        /// <summary>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <param name="c3">A collection of items.</param>
        /// <param name="colls">Rest of the collections of items.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in 
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2, object c3, params object[] colls)
        {
            return Invoke(
                new Function<object, object>(x => apply(f, x)),
                step(conj(colls, c3, c2, c1)));

            object step(object cs) =>
                new LazySeq(() =>
                {
                    var ss = Invoke(new Seq(), cs);
                    if ((bool)new IsEvery().Invoke(new Identity(), ss))
                    {
                        return cons(Invoke(new First(), ss), step(Invoke(new Rest(), ss)));
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
                ((IFunction<object, object, object>)this._rf).Invoke(result, ((IFunction<object, object>)this._f).Invoke(apply(this._f, input, inputs)));
        }
    }
}
