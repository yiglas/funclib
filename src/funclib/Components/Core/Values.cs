using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s values.
    /// </summary>
    public class Values :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s values.
        /// </summary>
        /// <param name="map">An object that implements the <see cref="IMap"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s values.
        /// </returns>
        public object Invoke(object map)
        {
            if (map is IMap m)
                return ValueSeq.Create(m);

            return ValueSeq.Create((ISeq)funclib.Core.Seq(map));
        }
    }
}
