﻿using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
    /// </summary>
    public class IsSequential :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
        /// </summary>
        /// <param name="coll">An object to test against.</param>
        /// <returns>
        /// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
        /// </returns>
        public object Invoke(object coll) => new IsInstance().Invoke(typeof(ISequential), coll);
    }
}