﻿using System;
using System.Collections.Generic;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
    /// </summary>
    public class IsLessThanOrEqualTo :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunctionParams<object, object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <returns>
        /// Returns true.
        /// </returns>
        public object Invoke(object x) => true;
        /// <summary>
        /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test.</param>
        /// <returns>
        /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y) => Numbers.IsLTE(x, y);
        /// <summary>
        /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="x">First element to test.</param>
        /// <param name="y">Second element to test.</param>
        /// <param name="more">Rest of the elements to test.</param>
        /// <returns>
        /// Returns a <see cref="true"/>, numbers are monotonically non-decreasing order, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object x, object y, params object[] more)
        {
            if ((bool)Invoke(x, y))
            {
                var n = next(more);
                if ((bool)new Truthy().Invoke(n))
                    return Invoke(y, first(more), (object[])new ToArray().Invoke(n));

                return Invoke(y, first(more));
            }

            return false;
        }
    }
}
