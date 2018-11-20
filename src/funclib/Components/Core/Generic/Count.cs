using funclib.Collections;
using System;

namespace funclib.Components.Core.Generic
{
    public class Count<T> :
        IFunction<T, int>
    {
        public int Invoke(T coll)
        {
            if (coll is ICounted counted) 
                return counted.Count;
            else if (coll is ICollection collection)
                return CountCollection();
            
            return 0;
        }

        static int CountCollection() => -1;
    }
}
