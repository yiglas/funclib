using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
    /// </summary>
    public class Interleave :
        IFunction<object>,
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </summary>
        /// <returns>
        /// Returns <see cref="Collections.List.EMPTY"/>.
        /// </returns>
        public object Invoke() => funclib.Core.List();
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">The collection returned lazily.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of c1.
        /// </returns>
        public object Invoke(object c1) => funclib.Core.LazySeq(c1);
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">First collection to interleave.</param>
        /// <param name="c2">Second collection to interleave.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </returns>
        public object Invoke(object c1, object c2) =>
            funclib.Core.LazySeq(() =>
            {
                var s1 = funclib.Core.Seq(c1);
                var s2 = funclib.Core.Seq(c2);
                if ((bool)funclib.Core.Truthy(funclib.Core.And(s1, s2)))
                {
                    return funclib.Core.Cons(
                        funclib.Core.First(s1), 
                        funclib.Core.Cons(
                            funclib.Core.First(s2), 
                            Invoke(
                                funclib.Core.Rest(s1), 
                                funclib.Core.Rest(s2))));
                }

                return null;
            });
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </summary>
        /// <param name="c1">First collection to interleave.</param>
        /// <param name="c2">Second collection to interleave.</param>
        /// <param name="colls">Rest of the collections to interleave.</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of the funclib.Core.First( item in each coll, then the second, etc.
        /// </returns>
        public object Invoke(object c1, object c2, params object[] colls) =>
            funclib.Core.LazySeq(() =>
            {
                var ss = funclib.Core.Map(
                    funclib.Core.seq, 
                    funclib.Core.Conj(funclib.Core.Seq(colls), c2, c1));
                if ((bool)funclib.Core.IsEvery(funclib.Core.identity, ss))
                {
                    return funclib.Core.Concat(
                        funclib.Core.Map(
                            funclib.Core.first, 
                            ss), 
                        funclib.Core.Apply(
                            this, 
                            funclib.Core.Map(funclib.Core.rest, ss)));
                }
                return null;
            });
    }
}
