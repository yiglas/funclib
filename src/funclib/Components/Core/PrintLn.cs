﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Components.Core
{
    /// <summary>
    /// The same as <see cref="Print"/> but followed by a <see cref="Environment.NewLine"/>.
    /// </summary>
    public class PrintLn :
        IFunctionParams<object, object>
    {
        /// <summary>
        /// The same as <see cref="Print"/> but followed by a <see cref="Environment.NewLine"/>.
        /// </summary>
        /// <param name="more">Any objects you want to print.</param>
        /// <returns>
        /// Returns null.
        /// </returns>
        public object Invoke(params object[] more)
        {
            new Apply().Invoke(new Print(), more);
            Variables.Out.Write(Environment.NewLine);
            Variables.Out.Flush();
            return null;
        }
    }
}