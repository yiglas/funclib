using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if source is a logical true. i.e.:
    /// source is not null or if source is boolean true.
    /// </summary>
    public class Truthy :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if source is a logical true. i.e.:
        /// source is not null or if source is boolean true.
        /// </summary>
        /// <param name="source">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if source is a logical true. i.e.:
        /// source is not null or if source is boolean true.
        /// </returns>
        public object Invoke(object source) => !((bool)(new Falsy().Invoke(source)));
    }
}
