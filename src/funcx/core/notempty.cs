namespace funcx
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class core
    {
        /// <summary>
        /// If the source is empty return null else return source.
        /// </summary>
        /// <param name="coll">The <see cref="object"/>.</param>
        /// <returns>
        /// Either null if object is empty else the object.
        /// </returns>
        public static object notempty(object coll)
        {
            if (falsy(coll)) return null;
            else if (coll is ICollection) return (coll as ICollection).Count > 0 ? coll : null;
            else if (coll is string) return (coll as string).Length > 0 ? coll : null;
            else if (coll is IEnumerable)
            {
                foreach (var item in (coll as IEnumerable))
                    return coll;
            }

            return null;
        }
    }
}
