using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Evaluates objects one at a time, from left to right. If a object returns 
    /// a logical false (null or false) then it is returned and stops evaluating
    /// all other expressions. Otherwise, it returns the value of the last object.
    /// </summary>
    public class And :
        IFunction<object>,
        IFunction<object, object>,
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical false (null or false) then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <returns>
        /// Returns true.
        /// </returns>
        public object Invoke() => true;

        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical false (null or false) then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <param name="x">Object to return.</param>
        /// <remarks>
        /// If x implements interface <see cref="IFunction{TResult}"/> then the object's
        /// Invoke() method is executed and sets its results to x.
        /// </remarks>
        /// <returns>
        /// Returns x or the result of calling Invoke on x.
        /// </returns>
        public object Invoke(object x)
        {
            if (x != null)
            {
                if (x.GetType().GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IFunction<>)))
                {
                    dynamic f = x;
                    x = f.Invoke();
                }
            }

            return x;
        }

        /// <summary>
        /// Evaluates objects one at a time, from left to right. If a object returns 
        /// a logical false (null or false) then it is returned and stops evaluating
        /// all other expressions. Otherwise, it returns the value of the last object.
        /// </summary>
        /// <param name="x">First object to test.</param>
        /// <param name="next">Rest of the objects to test.</param>
        /// <remarks>
        /// If x implements interface <see cref="IFunction{TResult}"/> then the object's
        /// Invoke() method is executed and sets its results to x.
        /// </remarks>
        /// <returns>
        /// Returns the first logical false, otherwise the last object evaluated.
        /// </returns>
        public object Invoke(object x, params object[] next)
        {
            if (next == null || next.Length <= 0)
                return Invoke(x);

            if (x != null)
            {
                if (x.GetType().GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IFunction<>)))
                {
                    dynamic f = x;
                    x = f.Invoke();
                }
            }

            if ((bool)new Truthy().Invoke(x))
                return Invoke(next[0], next.Skip(1).ToArray());
            
            return x;
        }
    }
}
