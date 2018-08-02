using funclib.Components.Core.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a number one less than num.
    /// </summary>
    public class Dec :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a number one less than num.
        /// </summary>
        /// <param name="x">A number to decrease by one.</param>
        /// <returns>
        /// Returns either a <see cref="double"/> or <see cref="long"/> depending on 
        /// what type x is.
        /// </returns>
        public object Invoke(object x) => Numbers.Dec(x);
    }
}
