using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// For <see cref="LazySeq"/> that are produced via other functions and have side effects. 
    /// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/> 
    /// walks though successive next, retains the head and returns it, thus causing the 
    /// entire seq to reside in memory at one time.
    /// </summary>
    public class DoAll :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// For <see cref="LazySeq"/> that are produced via other functions and have side effects. 
        /// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/> 
        /// walks though successive next, retains the head and returns it, thus causing the 
        /// entire seq to reside in memory at one time.
        /// </summary>
        /// <param name="coll"><see cref="LazySeq"/> to consume.</param>
        /// <returns>
        /// Returns the <see cref="LazySeq"/> already consumed.
        /// </returns>
        public object Invoke(object coll)
        {
            doRun(coll);
            return coll;
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
        /// Returns the <see cref="LazySeq"/> already consumed.
        /// </returns>
        public object Invoke(object n, object coll)
        {
            doRun(n, coll);
            return coll;
        }
    }
}
