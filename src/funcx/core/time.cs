namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        // TODO: figure out how to change the Console.writeline to anything the developer wants.

        /// <summary>
        /// Evaluates expr and prints the time it took. Returns the value of expr.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
        /// <param name="expr">The function to evaluate.</param>
        /// <returns>
        /// The results of expr.
        /// </returns>
        public static TResult time<TResult>(Func<TResult> expr)
        {
            TResult result = default;

            var sw = Stopwatch.StartNew();
            if (expr != null)
                result = expr();

            sw.Stop();
            Debug.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} msecs");

            return result;
        }

        /// <summary>
        /// Evaluates expr and prints the time it took. Returns null.
        /// </summary>
        /// <param name="expr">The action to evaluate.</param>
        /// <returns>
        /// null
        /// </returns>
        public static object time(Action expr)
        {
            var sw = Stopwatch.StartNew();
            if (expr != null)
                expr();

            sw.Stop();
            Debug.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} msecs");

            return null;
        }
    }
}
