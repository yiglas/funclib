namespace FunctionalLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class core
    {
        /// <summary>
        /// Returns the groups form the most recent match/find. If there are no 
        /// nested groups, returns a List of the entire match. If there are
        /// nested groups, returns a List of the groups, the first element
        /// being the entire match.
        /// </summary>
        /// <param name="m">The <see cref="ReMatcher"/> object.</param>
        /// <returns>
        /// Returns a List found matches.
        /// </returns>
        public static IList<string> regroups(ReMatcher m)
        {
            if (m == null) return null;

            var count = m.GroupCount();
            if (count != 0)
            {
                m.Group();

                Func<IList<string>, int, IList<string>> inter = null;
                inter = (ret, cnt) =>
                {
                    if (cnt <= count)
                    {
                        return inter(conj(ret, m.Group(cnt)), inc(cnt));
                    }
                    return ret;
                };

                return inter(new List<string>(), 0);
            }
            else
                return new List<string>() { m.Value() };
        }
    }
}
