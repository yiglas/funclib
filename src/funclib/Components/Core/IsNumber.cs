﻿using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
    /// </summary>
    public class IsNumber :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">Object to test.</param>
        /// <returns>
        /// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x) => Numbers.IsNumber(x);
    }
}