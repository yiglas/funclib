using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// For <see cref="LazySeq"/> that are produced via other functions and have side effects. 
    /// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/> 
    /// walks though successive next, retains the head and returns it, thus causing the 
    /// entire seq to reside in memory at one time.
    /// </summary>
    public class DoRun :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// For <see cref="LazySeq"/> that are produced via other functions and have side effects. 
        /// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/> 
        /// walks though successive next, retains the head and returns it, thus causing the 
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="coll">A <see cref="LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object coll)
        {
            var s = funclib.Core.Seq(coll);
            if ((bool)funclib.Core.Truthy(s))
            {
                return Invoke(funclib.Core.Next(s));
            }
            return null;
        }
        /// <summary>
        /// For <see cref="LazySeq"/> that are produced via other functions and have side effects. 
        /// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/> 
        /// walks though successive next, retains the head and returns it, thus causing the 
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="n">The <see cref="int"/> times to walk the sequence.</param>
        /// <param name="coll"><see cref="LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            var s = funclib.Core.Seq(coll);   
            if ((bool)funclib.Core.Truthy(funclib.Core.And(s, funclib.Core.IsPos(n))))
            {
                return Invoke(funclib.Core.Dec(n), funclib.Core.Next(s));
            }
            return null;
        }
    }
}
