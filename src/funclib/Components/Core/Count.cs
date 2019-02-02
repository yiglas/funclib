using funclib.Collections;
using funclib.Components.Core.Generic;
using System;

namespace funclib.Components.Core
{
    /// <summary>
    /// Returns the number of items in the collection. Passing null as coll returns 0.
    /// </summary>
    public class Count :
        IFunction<object, object>
    {
        /// <summary>
        /// Returns the number of items in the collection. Passing null as coll returns 0.
        /// </summary>
        /// <param name="coll">Object to count the number of items exists in the collection.</param>
        /// <remarks>
        /// <code>coll</code> can be:
        /// - <see cref="ICounted"/>
        /// - <see cref="ICollection"/>
        /// - <see cref="string"/>
        /// - <see cref="System.Collections.ICollection"/>
        /// - <see cref="System.Collections.IDictionary"/>
        /// - <see cref="System.Collections.DictionaryEntry"/>
        /// - <see cref="KeyValuePair"/>
        /// - <see cref="Array"/>
        /// </remarks>
        /// <returns>
        /// Returns an <see cref="int"/> of the number of items in the collection.
        /// </returns>
        public object Invoke(object coll) 
        {
            if (coll is ICounted c)
                return c.Count;
            
            return CountFrom(Ret(coll, coll is null));
        }

        static int CountFrom(object coll)
        {
            switch (coll)
            {
                case null: 
                    return 0;
                case System.Collections.DictionaryEntry d:
                case KeyValuePair kvp:
                    return 2;
                case ICollection c1:
                    return CountCollection(coll);
                case System.Collections.ICollection c:
                    return c.Count;
            }

            throw new InvalidOperationException($"Count not supported on this type: {coll.GetType().FullName}");
        }

        static int CountCollection(object o)
        {
            var s = (ISeq)funclib.Core.Seq(o);
            o = null;
            int i = 0;
            for(; s != null; s = s.Next())
            {
                if (s is ICounted)
                    return i + s.Count;
                i++;
            }
            return i;
        }

        static object Ret(object ret, object nullable) => ret;
    }
}
