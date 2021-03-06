﻿using funclib.Collections;
using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="Collections.SortedMap"/> with supplied mappings, using the supplied
    /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
    /// if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
    /// </summary>
    public class SortedMapBy :
        IFunctionParams<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="Collections.SortedMap"/> with supplied mappings, using the supplied
        /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
        /// if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
        /// </summary>
        /// <param name="comparator">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
        /// <param name="keyvals">Key/value pairs adding to the <see cref="Collections.SortedMap"/> data structure.</param>
        /// <returns>
        /// Returns a <see cref="Collections.SortedMap"/> with supplied mappings, using the supplied
        /// <see cref="IFunction{T1, T2, TResult}"/> comparator. If any keys are equal, they are handled as
        /// if by repeated uses of <see cref="funclib.Components.Core.Assoc"/>.
        /// </returns>
        public object Invoke(object comparator, params object[] keyvals) => Collections.SortedMap.Create(new FunctionComparer(comparator), (ISeq)funclib.Core.Seq(keyvals));
    }
}
