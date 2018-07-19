﻿using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// For <see cref="Collections.List"/> or <see cref="Collections.Queue"/> returns a 
    /// new <see cref="Collections.List"/>/<see cref="Collections.Queue"/> without the first
    /// item. For <see cref="Collections.Vector"/>, returns a new <see cref="Collections.Vector"/>
    /// without the last time. If the coll is empty, throws an exception.
    /// </summary>
    public class Pop :
        IFunction<object, object>
    {
        /// <summary>
        /// For <see cref="Collections.List"/> or <see cref="Collections.Queue"/> returns a 
        /// new <see cref="Collections.List"/>/<see cref="Collections.Queue"/> without the first
        /// item. For <see cref="Collections.Vector"/>, returns a new <see cref="Collections.Vector"/>
        /// without the last time. If the coll is empty, throws an exception.
        /// </summary>
        /// <param name="coll">An object that implements a <see cref="IStack"/> interface.</param>
        /// <returns>
        /// Returns the same collection type as the input, minus the last item in a <see cref="Collections.Vector"/>
        /// or first time in a <see cref="Collections.List"/> or <see cref="Collections.Queue"/>
        /// </returns>
        public object Invoke(object coll) => coll == null ? null : ((IStack)coll).Pop();
    }
}
