namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        // TODO: remove object and to got passing in generics

        /// <summary>
        /// Evaluates expressions one at a time, from left to right. If a form
        /// returns a logical true value, it returns that value and doesn't 
        /// evaluate any of the other expressions, otherwise it returns the value
        /// of the last expression. null.Or() returns null.
        /// </summary>
        /// <param name="x">The <see cref="object"/>.</param>
        /// <param name="next">Next evaluated expressions.</param>
        /// <returns>
        /// returns the results of evaluated from left to right.
        /// </returns>
        public static object or(object x, params object[] next)
        {
            if (x == null && next.Count() == 0) return null;
            else if (next.Count() == 0)
            {
                if (x == null)
                    return null;

                return x is Delegate ? (x as Delegate).DynamicInvoke() : x;
            }

            Func<IEnumerable, object, object> inter = null;
            inter = (more, val) =>
            {
                if (count(more) > 0)
                {
                    var t = or(first(more));
                    if (truthy(t))
                        return t;

                    var n = core.next(more);
                    if (n == null)
                        return t;

                    return inter(n, t);
                }
                else return val;
            };

            var f = or(x);
            if (truthy(f))
                return f;

            return inter(seq(next), null);
        }
    }
}
