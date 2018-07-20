﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="false"/> if x is logical true for any item in coll, otherwise <see cref="true"/>.
    /// </summary>
    public class IsNotAny :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
        /// <param name="coll">A collection of items to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object pred, object coll) =>
            ((IFunction<object, object, object>)new Comp().Invoke(new Not(), new Some())).Invoke(pred, coll);
    }
}