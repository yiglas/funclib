using System.Linq;

namespace funclib.Components.Core.Generic
{
    public partial class Stuff
    {
        public static bool And() => true;
        public static T And<T>(T x) => x;
        public static T And<T>(T x, params T[] next)
        {
            if (Truthy(x) && && (next?.Length ?? 0) > 0)
            {
                return And(next[0], next.Skip(1).ToArray());
            }

            return x;
        }
    }
}