using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the groups from the most recent match/find. If there are no
    /// nested groups, returns a string of the entire match. If there are 
    /// nested groups, returns a <see cref="Collections.Vector"/> of groups,
    /// the first element being the entire match.
    /// </summary>
    public class ReGroups :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the groups from the most recent match/find. If there are no
        /// nested groups, returns a string of the entire match. If there are 
        /// nested groups, returns a <see cref="Collections.Vector"/> of groups,
        /// the first element being the entire match.
        /// </summary>
        /// <param name="m">A <see cref="ReMatcher"/> instance.</param>
        /// <returns>
        /// Returns the groups from the most recent match/find. If there are no
        /// nested groups, returns a string of the entire match. If there are 
        /// nested groups, returns a <see cref="Collections.Vector"/> of groups,
        /// the first element being the entire match.
        /// </returns>
        public object Invoke(object m)
        {
            var matcher = (ReMatcher)m;
            var gc = matcher.GroupCount();
            if (gc == 0)
                return matcher.Group();

            return loop(new Vector().Invoke());

            object loop(object ret, int c = 0)
            {
                if (c <= gc)
                    return loop(conj(ret, matcher.Group(c)), (int)inc(c));

                return ret;
            }
        }
    }
}
