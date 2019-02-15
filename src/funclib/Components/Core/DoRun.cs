using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
    /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
    /// walks though successive next, retains the head and returns it, thus causing the
    /// entire seq to reside in memory at one time.
    /// </summary>
    public class DoRun :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
        /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
        /// walks though successive next, retains the head and returns it, thus causing the
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="coll">A <see cref="funclib.Components.Core.LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object coll)
        {
            var s = funclib.Core.Seq(coll);
            if (funclib.Core.T(s))
            {
                return Invoke(funclib.Core.Next(s));
            }
            return null;
        }
        /// <summary>
        /// For <see cref="funclib.Components.Core.LazySeq"/> that are produced via other functions and have side effects.
        /// The side effects are not produces until the sequence is consumed. <see cref="funclib.Components.Core.DoAll"/>
        /// walks though successive next, retains the head and returns it, thus causing the
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="n">The <see cref="int"/> times to walk the sequence.</param>
        /// <param name="coll"><see cref="funclib.Components.Core.LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            var s = funclib.Core.Seq(coll);
            if (funclib.Core.T(funclib.Core.And(s, funclib.Core.IsPos(n))))
            {
                return Invoke(funclib.Core.Dec(n), funclib.Core.Next(s));
            }
            return null;
        }
    }
}
