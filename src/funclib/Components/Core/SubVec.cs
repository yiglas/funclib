using funclib.Collections;
using System;
using System.Text;

namespace funclib.Components.Core
{
    public class SubVec :
        IFunction<object, object, object>,
        IFunction<object, object, object, object>
    {
        public object Invoke(object v, object start) => Invoke(v, start, new Count().Invoke(v));
        public object Invoke(object v, object start, object end)
        {
            var vec = (IVector)v;

            var s = (int)start;
            if (s < 0) throw new ArgumentOutOfRangeException(nameof(start), $"{nameof(start)} cannot be less than zero.");

            var e = (int)end;
            if (e < s) throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} cannot be less than {nameof(start)}.");
            if (e > vec.Count) throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)} cannot be greater than the end of the vector.");

            if (s == e) return Collections.Vector.EMPTY;

            return SubVector.Create(vec, s, e);
        }
    }
}
