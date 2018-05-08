namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        public static bool? some<T>(Func<T, bool> pred, IEnumerable<T> coll) => coll.Where(pred).Any();
    }
}
