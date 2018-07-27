using System;
using System.Text;
using static funclib.core;

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
        public object Invoke(object f) => func<object, object>(rf => new TransducerFunction(f, rf));
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
        public object Invoke(object f, object coll)=> 
            lazySeq(() =>
            {
                var s = seq(coll);
                if ((bool)truthy(s))
                {
                    if ((bool)isChunkedSeq(s))
                    {
                        var c = chunkFirst(s);
                        var size = (int)count(c);
                        var b = (Collections.ChunkBuffer)chunkBuffer(size);

                        doTimes(size, 
                            i => chunkAppend(b, invoke(f, nth(c, i))));

                        return chunkCons(b.Chunk(), Invoke(f, chunkRest(s)));
                    }
                    else
                        return cons(invoke(f, first(s)), Invoke(f, rest(s)));
                }

                return null;
            });
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
        public object Invoke(object f, object c1, object c2) =>
            lazySeq(() =>
            {
                var s1 = seq(c1);
                var s2 = seq(c2);
                if ((bool)truthy(and(s1, s2)))
                {
                    return cons(invoke(f, first(s1), first(s2)), Invoke(f, rest(s1), rest(s2)));
                }

                return null;
            });
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
        public object Invoke(object f, object c1, object c2, object c3) =>
            lazySeq(() =>
            {
                var s1 = seq(c1);
                var s2 = seq(c2);
                var s3 = seq(c3);
                if ((bool)truthy(and(s1, s2, s3)))
                {
                    return cons(invoke(f, first(s1), first(s2), first(s1)), Invoke(f, rest(s1), rest(s2), rest(s3)));
                }

                return null;
            });
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
            return Invoke(func((object x) => apply(f, x)), step(conj(colls, c3, c2, c1)));

            object step(object cs) =>
                lazySeq(() =>
                {
                    var ss = Invoke(funclib.core.Seq, cs);
                    if ((bool)isEvery(funclib.core.Identity, ss))
                    {
                        return cons(Invoke(funclib.core.First, ss), step(Invoke(funclib.core.Rest, ss)));
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
            public override object Invoke(object result, object input) => invoke(this._rf, result, invoke(this._f, input));
            #endregion

            public object Invoke(object result, object input, params object[] inputs) =>
                invoke(this._rf, result, invoke(this._f, apply(this._f, input, inputs)));
        }
    }
}
