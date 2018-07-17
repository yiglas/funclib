using funclib.Collections;
using funclib.Collections.Internal;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
    /// </summary>
    public class Keys :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
        /// </summary>
        /// <param name="coll">An object that implements the <see cref="IMap"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
        /// </returns>
        public object Invoke(object coll)
        {
            if (coll is IMap map)
                return KeySeq.Create(map);

            return KeySeq.Create((ISeq)new Seq().Invoke(coll));
        }
    }
}
