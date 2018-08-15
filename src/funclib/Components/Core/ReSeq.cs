using funclib.Components.Core.Generic;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns a <see cref="LazySeq"/> of successive matches of pattern in string,
    /// using <see cref="ReMatcher.Find"/>, each such match processed with <see cref="ReGroups"/>.
    /// </summary>
    public class ReSeq :
        IFunction<object, object, object>
    {
        /// <summary>
        /// Returns a <see cref="LazySeq"/> of successive matches of pattern in string,
        /// using <see cref="ReMatcher.Find"/>, each such match processed with <see cref="ReGroups"/>.
        /// </summary>
        /// <param name="re">An object that is already a <see cref="Regex"/> instance.</param>
        /// <param name="s">The string to search for a match(s).</param>
        /// <returns>
        /// Returns a <see cref="LazySeq"/> of successive matches of pattern in string,
        /// using <see cref="ReMatcher.Find"/>, each such match processed with <see cref="ReGroups"/>.
        /// </returns>
        public object Invoke(object re, object s)
        {
            var m = (ReMatcher)funclib.Core.ReMatcher(re, s);

            return step();

            object step()
            {
                if (m.Find())
                    return funclib.Core.Cons(funclib.Core.ReGroups(m), funclib.Core.LazySeq(step));

                return null;
            }
        }
    }
}
