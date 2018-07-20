﻿using System;
using System.Text;

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
            var s = new Seq().Invoke(coll);
            if ((bool)new Truthy().Invoke(s))
            {
                return Invoke(new Next().Invoke(s));
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
            var s = new Seq().Invoke(coll);            
            if ((bool)new Truthy().Invoke(s) && (bool)new IsPos().Invoke(n))
            {
                return Invoke(new Dec().Invoke(n), new Next().Invoke(s));
            }
            return null;
        }
    }
}