﻿using FunctionalLibrary.Collections;
using FunctionalLibrary.Collections.Internal;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    /// <summary>
    /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
    /// </summary>
    public class Find :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
        /// </summary>
        /// <param name="map">An object that implements either <see cref="IAssociative"/>, <see cref="System.Collections.IDictionary"/> or <see cref="ITransientAssociative"/> interface.</param>
        /// <param name="key">The key we want to find in the map.</param>
        /// <returns>
        /// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
        /// </returns>
        public object Invoke(object map, object key) =>
            map == null
                ? null
                : map is IAssociative a ? a.Get(key)
                : map is System.Collections.IDictionary d ? d.Contains(key) ? KeyValuePair.Create(key, d[key]) : null
                : map is ITransientAssociative t ? t.Get(key)
                : null;
    }
}
