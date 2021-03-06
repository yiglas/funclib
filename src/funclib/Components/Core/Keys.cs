﻿using funclib.Collections;
using funclib.Collections.Internal;
using funclib.Components.Core.Generic;

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
        /// <param name="map">An object that implements the <see cref="IMap"/> interface.</param>
        /// <returns>
        /// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
        /// </returns>
        public object Invoke(object map)
        {
            if (map is IMap m)
                return KeySeq.Create(m);

            return KeySeq.Create((ISeq)funclib.Core.Seq(map));
        }
    }
}
