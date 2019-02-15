using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
    /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
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
        public object Invoke(object f) => funclib.Core.Func(rf => new TransducerFunction(f, rf));
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="coll">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object coll)=>
            funclib.Core.LazySeq(() =>
            {
                var s = funclib.Core.Seq(coll);
                if (funclib.Core.T(s))
                {
                    if ((bool)funclib.Core.IsChunkedSeq(s))
                    {
                        var c = funclib.Core.ChunkFirst(s);
                        var size = (int)funclib.Core.Count(c);
                        var b = (Collections.ChunkBuffer)funclib.Core.ChunkBuffer(size);

                        funclib.Core.DoTimes(size,
                            i => funclib.Core.ChunkAppend(b, funclib.Core.Invoke(f, funclib.Core.Nth(c, i))));

                        return funclib.Core.ChunkCons(b.Chunk(), Invoke(f, funclib.Core.ChunkRest(s)));
                    }
                    else
                        return funclib.Core.Cons(funclib.Core.Invoke(f, funclib.Core.First(s)), Invoke(f, funclib.Core.Rest(s)));
                }

                return null;
            });
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2) =>
            funclib.Core.LazySeq(() =>
            {
                var s1 = funclib.Core.Seq(c1);
                var s2 = funclib.Core.Seq(c2);
                if (funclib.Core.T(funclib.Core.And(s1, s2)))
                {
                    return funclib.Core.Cons(funclib.Core.Invoke(f, funclib.Core.First(s1), funclib.Core.First(s2)), Invoke(f, funclib.Core.Rest(s1), funclib.Core.Rest(s2)));
                }

                return null;
            });
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <param name="c3">A collection of items.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2, object c3) =>
            funclib.Core.LazySeq(() =>
            {
                var s1 = funclib.Core.Seq(c1);
                var s2 = funclib.Core.Seq(c2);
                var s3 = funclib.Core.Seq(c3);
                if (funclib.Core.T(funclib.Core.And(s1, s2, s3)))
                {
                    return funclib.Core.Cons(funclib.Core.Invoke(f, funclib.Core.First(s1), funclib.Core.First(s2), funclib.Core.First(s1)), Invoke(f, funclib.Core.Rest(s1), funclib.Core.Rest(s2), funclib.Core.Rest(s3)));
                }

                return null;
            });
        /// <summary>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </summary>
        /// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
        /// <param name="c1">A collection of items.</param>
        /// <param name="c2">A collection of items.</param>
        /// <param name="c3">A collection of items.</param>
        /// <param name="colls">Rest of the collections of items.</param>
        /// <returns>
        /// Returns a <see cref="funclib.Components.Core.LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
        /// to the set of funclib.Core.First( items of each coll, followed by applying <see cref="IFunction"/> to the set
        /// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
        /// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
        /// </returns>
        public object Invoke(object f, object c1, object c2, object c3, params object[] colls)
        {
            return Invoke(funclib.Core.Func((object x) => funclib.Core.Apply(f, x)), step(funclib.Core.Conj(colls, c3, c2, c1)));

            object step(object cs) =>
                funclib.Core.LazySeq(() =>
                {
                    var ss = Invoke(funclib.Core.seq, cs);
                    if ((bool)funclib.Core.IsEvery(funclib.Core.identity, ss))
                    {
                        return funclib.Core.Cons(Invoke(funclib.Core.first, ss), step(Invoke(funclib.Core.rest, ss)));
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
            public override object Invoke(object result, object input) => funclib.Core.Invoke(this._rf, result, funclib.Core.Invoke(this._f, input));
            #endregion

            public object Invoke(object result, object input, params object[] inputs) =>
                funclib.Core.Invoke(this._rf, result, funclib.Core.Invoke(this._f, funclib.Core.Apply(this._f, input, inputs)));
        }
    }
}
