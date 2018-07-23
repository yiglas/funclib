using funclib.Collections;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Components.Core
{
    /// <summary>
    /// Creates a new <see cref="Collections.Vector"/> containing the items from coll.
    /// </summary>
    public class Vec :
        IFunction<object, object>
    {
        /// <summary>
        /// Creates a new <see cref="Collections.Vector"/> containing the items from coll.
        /// </summary>
        /// <param name="coll">A object that implements either <see cref="ISeq"/> or <see cref="System.Collections.IEnumerable"/> interface or anything that can be made into array via <see cref="ToArray"/> method.</param>
        /// <returns>
        /// Returns a <see cref="Collections.Vector"/> object. If coll is null returns <see cref="Collections.Vector.EMPTY"/> object.
        /// </returns>
        public object Invoke(object coll)
        {
            if (coll == null) return Collections.Vector.EMPTY;
            else if (coll is ISeq s)
            {
                var sq = (ISeq)seq(s);
                if (sq == null)
                    return Collections.Vector.EMPTY;

                return Collections.Vector.Create(sq);
            }
            else if (coll is System.Collections.IEnumerable e) return Collections.Vector.Create(e);
            else
                return Collections.Vector.Create((object[])toArray(coll));
        }
    }
}
