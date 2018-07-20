﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a sorted collection of the items in coll. If no comparator is 
    /// supplied, use <see cref="Compare"/>.
    /// </summary>
    public class Sort :
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </summary>
        /// <param name="coll">A collection to be sorted.</param>
        /// <returns>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object coll) => Invoke(new Compare(), coll);
        /// <summary>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </summary>
        /// <param name="comp">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="coll">A collection to be sorted.</param>
        /// <returns>
        /// Returns a sorted collection of the items in coll. If no comparator is 
        /// supplied, use <see cref="Compare"/>.
        /// </returns>
        public object Invoke(object comp, object coll)
        {
            if ((bool)new Truthy().Invoke(new Seq().Invoke(coll)))
            {
                var a = (object[])new ToArray().Invoke(coll);
                Array.Sort(a, new FunctionComparer(comp));
                return new Seq().Invoke(a);
            }
            return new List().Invoke();
        }
            
    }
}