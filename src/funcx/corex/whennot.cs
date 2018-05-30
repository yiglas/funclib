namespace FunctionalLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// Evaluates test, if logically false, evaluates body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="test"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static TResult whennot<T, TResult>(T test, Func<T, TResult> body)
        {
            if (!truthy(test))
                return body(test);

            return default;
        }
    }
}
