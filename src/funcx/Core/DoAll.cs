using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
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
            new DoRun().Invoke(coll);
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
            new DoRun().Invoke(n, coll);
            return coll;
        }
    }
}
