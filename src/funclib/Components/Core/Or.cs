using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Evaluates objects one at a time, from left to right. If a object returns 
    /// a logical true value then it is returned and stops evaluating
    /// all other expressions. Otherwise, it returns the value of the last object.
    /// </summary>
    public class Or :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical true value then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke() => null;
        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical true value then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <param name="x">Object to return.</param>
        /// <remarks>
        /// If x implements interface <see cref="IFunction{TResult}"/> then the object's
        /// Invoke() method is executed and sets its results to x.
        /// </remarks>
        /// <returns>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical true value then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </returns>
        public object Invoke(object x) => x;
        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical true value then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="next">Rest of the objects to test.</param>
        /// <returns>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical true value then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </returns>
        public object Invoke(object x, params object[] next)
        {
            if ((bool)truthy(x))
                return x;

            if ((next?.Length ?? 0) <= 0)
                return x;

            return Invoke(next[0], next.Skip(1).ToArray());            
        }
    }
}
